using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StarkCrypto.Domains.Receives
{
 
    public class BinanceTicker24Receive
    {
        public string symbol { get; set; }
        public string symbolBitfinex { get; set; }
        public string priceChange { get; set; }
        public string priceChangePercent { get; set; }
        public string lastPrice { get; set; }
        public string lastQty { get; set; }
        public string bidPrice { get; set; }
        public string bidQty { get; set; }
        public string askPrice { get; set; }
        public string askQty { get; set; }
        public string openPrice { get; set; }
        public string highPrice { get; set; }
        public string lowPrice { get; set; }
        public string volume { get; set; }
        public string quoteVolume { get; set; }      

    }
}
