using System;
using System.Collections.Generic;

namespace VRGameSelectorServerDTO
{
    public class BookingReferenceEvent : EventArgs
    {

        public BookingReferenceEvent()
        {
            BookingReference = new BookingReference();
        }

        public BookingReference BookingReference { get; set; }
    }
}
