using ProtoBuf;

namespace VRGameSelectorDTO
{
    [ProtoContract]
    public class Barcode
    {
        public Barcode()
        {

        }

        public Barcode(string barcodeReadout)
        {
            BarcodeReadout = barcodeReadout;
        }

        [ProtoMember(1)]
        public string BarcodeReadout { get; set; }
    }
}
