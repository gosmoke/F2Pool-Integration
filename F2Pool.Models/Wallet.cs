using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashRates.Models
{
    public class Wallet
    {
        public string currency { get; set; }
        public string address { get; set; }
        public string threshold { get; set; }
    }
}
