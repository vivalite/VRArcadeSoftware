using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace VRGameSelectorDTO
{
    [ProtoContract]
    public class EndNow
    {
        public EndNow()
        {
            Message = "";
        }

        public EndNow(string message)
        {
            Message = message;
        }

        [ProtoMember(1)]
        public string Message { get; set; }
    }
}
