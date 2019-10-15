using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using VRGameSelectorServerDTO;

namespace VRArcadeServer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDashboardService" in both code and config file together.
    [ServiceContract]
    public interface IDashboardService
    {
        [OperationContract]
        DashboardModuleInfo PopulateContent(string IP = "");

        [OperationContract]
        void BarcodeInput(string IP = "", string Barcode = "");

        [OperationContract]
        void MarkCleanProvided(string IP = "");

        [OperationContract]
        void MarkHelpProvided(string IP = "");

        [OperationContract]
        string PrintBarcodeWithBookingReference(string bookingRef = "", int waiverID = 0);

        [OperationContract]
        void BarcodeDonePrinting(int waiverID = 0, string bookingRef = "", bool isSuccess = false);
    }
}
