using ProtoBuf;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace VRGameSelectorServerDTO
{
    [Serializable]
    [ProtoContract]
    public class ImageInfo
    {
        private Image _image;

        public ImageInfo()
        {
            ImageCRC = 0;
            ImageData = new byte[] { };
            IsImageChanged = false;
        }

        public ImageInfo(byte[] imageData) : this()
        {
            ImageData = imageData;
        }



        public Image Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
                Serialize();
                ImageCRC = Crc32C.Crc32CAlgorithm.Compute(ImageData);
            }
        }


        [ProtoMember(1)]
        public uint ImageCRC { get; set; }
        [ProtoMember(2)]
        public byte[] ImageData { get; set; }
        public Boolean IsImageChanged { get; set; }


        [ProtoBeforeSerialization]
        private void Serialize()
        {
            if (Image != null && IsImageChanged && ImageData.Length > 0)
            {
                //We need to decide how to convert our image to its raw binary form here
                using (MemoryStream inputStream = new MemoryStream())
                {
                    //For basic image types the features are part of the .net framework

                    ImageCodecInfo myImageCodecInfo;
                    Encoder myEncoder;
                    EncoderParameter myEncoderParameter;
                    EncoderParameters myEncoderParameters;

                    myImageCodecInfo = GetEncoderInfo("image/jpeg");
                    myEncoder = Encoder.Quality;
                    myEncoderParameters = new EncoderParameters(1);
                    myEncoderParameter = new EncoderParameter(myEncoder, 85L);
                    myEncoderParameters.Param[0] = myEncoderParameter;

                    Image.Save(inputStream, myImageCodecInfo, myEncoderParameters);

                    //If we wanted to include additional data processing here
                    //such as compression, encryption etc we can still use the features provided by NetworkComms.Net
                    //e.g. see DPSManager.GetDataProcessor<LZMACompressor>()

                    //Store the binary image data as bytes[]
                    ImageData = inputStream.ToArray();
                }
            }
        }

        [ProtoAfterDeserialization]
        private void Deserialize()
        {
            if (ImageData.Length > 0)
            {
                MemoryStream ms = new MemoryStream(ImageData);

                //If we added custom data processes we have the perform the reverse operations here before 
                //trying to recreate the image object
                //e.g. DPSManager.GetDataProcessor<LZMACompressor>()

                Image = Image.FromStream(ms);
                ImageCRC = Crc32C.Crc32CAlgorithm.Compute(ImageData);
            }

        }


        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }
    }
}
