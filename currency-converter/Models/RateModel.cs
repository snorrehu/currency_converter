using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace currency_converter.Models
{
    public class RateModel
    {
        public string Success { get; set; }
        public int Timestamp { get; set; }
        public string Base { get; set; }
        public string Date { get; set; }
        public List<string> Rates { get; set; }

    }
}
