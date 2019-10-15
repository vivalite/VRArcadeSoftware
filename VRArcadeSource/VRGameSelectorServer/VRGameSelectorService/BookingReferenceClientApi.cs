using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace VRArcadeServer
{
    public static class BookingReferenceClientApi
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public static event EventHandler OnBookingReferenceResult = delegate { };

        public static void GetBookingReferenceAsync(string apiUrl, string passcode)
        {
            apiUrl += "?passcode=" + passcode;
            var asyncClient = new WebClient();
            asyncClient.DownloadStringCompleted += asyncClient_DownloadStringCompleted;
            asyncClient.DownloadStringAsync(new Uri(apiUrl));

        }

        private static void asyncClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                try
                {

                    List<BookingReferenceJson> bookingRef = JsonConvert.DeserializeObject<List<BookingReferenceJson>>(e.Result);

                    BookingReferenceJsonEvent bre = new BookingReferenceJsonEvent()
                    {
                        ListBookingReference = bookingRef
                    };

                    OnBookingReferenceResult(null, bre);
                }
                catch (Exception ex)
                {
                    logger.Info("Error at asyncClient_DownloadStringCompleted: " + ex.Message);
                }

            }
        }
    }
}
