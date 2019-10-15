using ProtoBuf;
using System.Drawing;
using System.IO;

namespace VRGameSelectorDTO
{
    [ProtoContract]
    public class ImageInfo
    {
        private Image _image;

        public ImageInfo()
        {
            ImageCRC = 0;
            ImageData = new byte[] { };
            IsOnlyCRC = false;
        }

        public ImageInfo(byte[] imageData) : this()
        {
            ImageData = imageData;
            ImageCRC = Crc32C.Crc32CAlgorithm.Compute(imageData);
        }

        public ImageInfo(byte[] imageData, bool onlyCalculateCRC) : this()
        {
            ImageData = imageData;

            if (onlyCalculateCRC)
            {
                Deserialize();
                IsOnlyCRC = true;
                ImageData = new byte[] { };
                _image = null;
            }
            else
            {

            }


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
        [ProtoMember(3)]
        public bool IsOnlyCRC { get; set; }


        [ProtoBeforeSerialization]
        private void Serialize()
        {
            if (Image != null)
            {
                //We need to decide how to convert our image to its raw binary form here
                using (MemoryStream inputStream = new MemoryStream())
                {
                    //For basic image types the features are part of the .net framework
                    Image.Save(inputStream, Image.RawFormat);

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
            else
            {
                GetType();
            }

        }


    }
}
