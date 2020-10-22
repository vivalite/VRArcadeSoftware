// This is a part of the Microsoft POS for .NET SDK
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This sample source code is only intended as a 
// supplement to the POS for .NET SDK and related 
// electronic documentation provided with the library.


using System;
using Microsoft.PointOfService.BaseServiceObjects;
using System.Text;


namespace Microsoft.PointOfService.ExampleServiceObjects
{
	public sealed class MsrDataParser
	{
		private MsrDataParser () {}

		private static byte[] StringToByteArray(string source)
		{

	            return ASCIIEncoding.ASCII.GetBytes(source);
		}

        private static string RemoveSentinels(string trackData, string startSentinel, string endSentinel)
        {
            if (string.IsNullOrEmpty(trackData))
                return "";

            if (trackData.StartsWith(startSentinel, StringComparison.Ordinal) && trackData.EndsWith(endSentinel, StringComparison.Ordinal))
                return trackData.Substring(1, trackData.Length - 2);

            return trackData;
        }
        
        public static MsrFieldData ParseAamvaData(string track1Data, string track2Data, string track3Data)
        {
            if (track1Data == null)
                throw new ArgumentNullException("track1Data");

            if (track2Data == null)
                throw new ArgumentNullException("track2Data");

            if (track3Data == null)
                throw new ArgumentNullException("track3Data");


            MsrFieldData data = new MsrFieldData();
            int len;

            // Parse Track 1
            track1Data = RemoveSentinels(track1Data, "%", "?");
            if (track1Data.Length < 2)
                throw new PosControlException("Invalid Track1Data", ErrorCode.Failure);

            data.State = track1Data.Substring(0, 2);
            track1Data = track1Data.Substring(2);

            // city is up to the '^' or 13 chars
            int sep = track1Data.IndexOf('^');
            if (sep > 12 || (sep == -1 && track1Data.Length > 12))
                len = 13;
            else if (sep != -1)
                len = sep;
            else
                throw new PosControlException("Invalid Track1Data", ErrorCode.Failure);

            data.City = track1Data.Substring(0, len);
            track1Data = track1Data.Substring(len==13 ? len : len+1);


            // name is up to the '^' or 35 chars
            sep = track1Data.IndexOf('^');
            if (sep > 34 || (sep == -1 && track1Data.Length > 34))
                len = 35;
            else if (sep != -1)
                len = sep;
            else
                throw new PosControlException("Invalid Track1Data", ErrorCode.Failure);

            string [] names = track1Data.Substring(0, len).Split('$');
            if (names.Length > 0)
                data.Surname = names[0];
            if (names.Length > 1)
                data.FirstName = names[1];
            if (names.Length > 2)
                data.Suffix = names[2];

            track1Data = track1Data.Substring(len == 35 ? len : len + 1);

            // address is the rest of the string
            data.Address = track1Data.Trim('^');


            // Parse track 2
            track2Data = RemoveSentinels(track2Data, ";", "?");
            if (track2Data.Length < 6)
                throw new PosControlException("Invalid Track2Data", ErrorCode.Failure);
            // Skip ISO IIN
            track2Data = track2Data.Substring(6);

            // License #
            sep = track2Data.IndexOf('=');
            if (sep == -1)
                throw new PosControlException("Invalid Track2Data", ErrorCode.Failure);
            data.LicenseNumber = track2Data.Substring(0, sep);
            track2Data = track2Data.Substring(sep + 1);

            // Exp date, birth date
            if (track2Data.Length < 12)
                throw new PosControlException("Invalid Track2Data", ErrorCode.Failure);

            data.ExpirationDate = track2Data.Substring(0, 4);
            data.BirthDate = track2Data.Substring(4, 8);

            track2Data = track2Data.Substring(12);

            // License overflow
            track2Data = track2Data.TrimEnd('=');
            if (track2Data.Length > 0)
                data.LicenseNumber = data.LicenseNumber + track2Data;

            // Parse Track 3
            track3Data = RemoveSentinels(track3Data, "%", "?");
            if (track3Data.Length >= 42)
            {
                data.PostalCode = track3Data.Substring(2, 11);
                data.Class = track3Data.Substring(13, 2);
                data.Restrictions = track3Data.Substring(15, 10);
                data.Endorsements = track3Data.Substring(25, 4);
                data.Gender = track3Data.Substring(29, 1);
                data.Height = track3Data.Substring(30, 3);
                data.Weight = track3Data.Substring(33, 3);
                data.HairColor = track3Data.Substring(36, 3);
                data.EyeColor = track3Data.Substring(39, 3);
            }

            return data;
        }

		public static MsrFieldData ParseIsoData(string track1Data, string track2Data)
		{
			if (track1Data == null)
				throw new ArgumentNullException("track1Data");

			if (track2Data == null)
				throw new ArgumentNullException("track2Data");

			MsrFieldData data = new MsrFieldData();

			string [] Track1DataElements = track1Data.Trim().Split("^".ToCharArray());
			if (Track1DataElements.Length == 3 && 
				Track1DataElements[0].Length > 0 && 
				Track1DataElements[0][0] == 'B')
			{
				if (Track1DataElements[0].Length > 1)
					data.AccountNumber	= Track1DataElements[0].Substring(1);
				if (Track1DataElements[2].Length > 3)
					data.ExpirationDate	= Track1DataElements[2].Substring(0, 4);
				if (Track1DataElements[2].Length > 6)
					data.ServiceCode	= Track1DataElements[2].Substring(4, 3);
				
				// Track1DiscretionaryData
				if (Track1DataElements[2].Length > 7)
					data.Track1DiscretionaryData = StringToByteArray(Track1DataElements[2].Substring(7));
			
				// if the PAN contains a '/' then it's standard Visa format
				string [] PAN = Track1DataElements[1].Trim().Split("/".ToCharArray());
				if (PAN.Length == 2)
				{
					// Visa Format: "Surname/FirstName MiddleInitial.Title"
					
					// Surname is everything before '/' unless the PAN begins with "59" in which case
					// there will be a 3-digit country code before Surname
					if (data.AccountNumber.StartsWith("59", StringComparison.Ordinal))
					{
						if (PAN[0].Length > 2)
							data.Surname = PAN[0].Substring(3).Trim();  // skip 3-digit country code
					}
					else
					{
						data.Surname = PAN[0].Trim();
					}

					// Split the text to the right of the '/'
					string [] SplitPAN = PAN[1].Trim().Split(" ".ToCharArray());
					if (SplitPAN != null)
					{
						// FirstName is the first text to the right of '/'
						if (SplitPAN.Length > 0)
							data.FirstName = SplitPAN[0].Trim();

						if (SplitPAN.Length > 1)
						{
							// After FirstName is MiddleInitial.Title
							string [] splitInitial = SplitPAN[1].Trim().Split(".".ToCharArray());
							if (splitInitial.Length < 2)
							{
								data.MiddleInitial = SplitPAN[1].Trim();
							}
							else
							{
								data.MiddleInitial = splitInitial[0].Trim();
								data.Title = splitInitial[1].Trim();
							}
						}
					}
				}
				else
				{
					// Format: "FirstName MiddleInitial Surname Suffix"

					// Split PAN at spaces
					string [] SplitPAN = Track1DataElements[1].Trim().Split(" ".ToCharArray());

					if (SplitPAN.Length > 0)
						data.FirstName = SplitPAN[0].Trim();

					if (SplitPAN.Length == 2)
					{
						data.Surname = SplitPAN[1].Trim();
					}
					else if (SplitPAN.Length > 2)
					{
						data.MiddleInitial = SplitPAN[1].Trim();
						data.Surname = SplitPAN[2].Trim();

						if (SplitPAN.Length > 3)
							data.Suffix = SplitPAN[3].Trim();
					}
				}
			}
			
			string [] Track2DataElements = track2Data.Trim().Split("=".ToCharArray());
			if (Track2DataElements.Length == 2)
			{
				// If we didn't get these fields from track1 try to get them from track2
				if (data.AccountNumber.Length == 0)
					data.AccountNumber	= Track2DataElements[0].Trim();	
				if (data.ExpirationDate.Length == 0 && Track2DataElements[1].Length > 3)
					data.ExpirationDate	= Track2DataElements[1].Substring(0, 4);
				if (data.ServiceCode.Length == 0 && Track2DataElements[1].Length > 6)
					data.ServiceCode	= Track2DataElements[1].Substring(4, 3);

				// Track2DiscretionaryData
				if (Track2DataElements[1].Length > 7)
					data.Track2DiscretionaryData = StringToByteArray(Track2DataElements[1].Substring(7));
			}
		
			return data;
			
		}

	}
	
}
