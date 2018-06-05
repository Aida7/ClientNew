using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp1
{
    public class ClientData
    {
        public string Address { get; set; }
        public int Port { get; set; }
        public Socket SocketConnect { get; set; } 
        [JsonProperty("sender")]
        public string Sender { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("date")]
        public DateTime SentDate { get; set; }
        //public ClientData(Socket socket)
        //{
        //    SocketConnect = socket;
        //}
    }
}
