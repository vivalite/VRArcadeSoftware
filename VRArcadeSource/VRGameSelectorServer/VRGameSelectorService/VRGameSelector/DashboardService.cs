using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace VRArcadeServer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DashboardService" in both code and config file together.
    public class DashboardService : IDashboardService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void BarcodeInput(string IP = "", string Barcode = "")
        {
            VRGameSelectorServer vss = VRGameSelectorServer.Instance;
            vss.ProcessBarcode(IP, Barcode);
        }

        public void MarkCleanProvided(string IP = "")
        {
            VRGameSelectorServer vss = VRGameSelectorServer.Instance;
            vss.ResetCleaningStatusDashboard(IP);
        }

        public void MarkHelpProvided(string IP = "")
        {
            VRGameSelectorServer vss = VRGameSelectorServer.Instance;
            vss.ResetHelpRequestStatusDashboard(IP);
        }

        public DashboardModuleInfo PopulateContent(string IP = "")
        {
            VRGameSelectorServer vss = VRGameSelectorServer.Instance;
            return vss.PopulateDashboardModuleInfo(IP);
        }

        public string PrintBarcodeWithBookingReference(string bookingRef = "", int waiverID = 0)
        {
            logger.Info("PrintBarcodeWithBookingReference Input: " + bookingRef + waiverID.ToString());
            VRGameSelectorServer vss = VRGameSelectorServer.Instance;
            return vss.WaiverBarcodeGen(waiverID);
        }

        public void BarcodeDonePrinting(int waiverID = 0, string bookingRef = "", bool isSuccess = false)
        {
            logger.Info("PrintBarcodeWithBookingReference Input: " + waiverID.ToString() + isSuccess.ToString());
            VRGameSelectorServer vss = VRGameSelectorServer.Instance;
            vss.MarkWaiverReceived(null, new List<VRGameSelectorServerDTO.WaiverInfo>() {
                new VRGameSelectorServerDTO.WaiverInfo() {
                     ID = waiverID,
                     BookingReference = new VRGameSelectorServerDTO.BookingReference() { Reference = bookingRef }
            }});

        }
    }
}
