using System;
using System.Collections.Generic;

namespace VRGameSelectorServerDTO
{
    public class ClientEvent : EventArgs
    {

        public ClientEvent()
        {
            ListClients = new List<Client>();
        }

        public List<Client> ListClients { get; set; }
    }
}
