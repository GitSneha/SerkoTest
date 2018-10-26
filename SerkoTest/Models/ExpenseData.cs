using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace SerkoTest.Models
{
    public class ExpenseData
    {
        public string costcenter { get; set; } = "UNKNOWN";
        public string paymentmenthod { get; set; }
        public string vendor { get; set; }
        public string description { get; set; }
        public string date { get; set; }
        public string totalwithgst { get; set; }
        public Double totalwithoutgst { get; set; }
        public Double gst { get; set; }
        public string error { get; set; }
    }
}