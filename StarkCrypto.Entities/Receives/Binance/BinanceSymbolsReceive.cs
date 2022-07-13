using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StarkCrypto.Domains.Models
{
    public class BinanceSymbolsReceive
    {        
        public List<symbols> Symbols { get; set; }         
    }

    public class symbols
    {
        public string Symbol { get; set; }
        public string status { get; set; }
        public string baseAsset { get; set; }
        public string baseAssetPrecision { get; set; }
        public string quoteAsset { get; set; }
        public string quotePrecision { get; set; }
        public string quoteAssetPrecision { get; set; }
        public string baseCommissionPrecision { get; set; }
        public string quoteCommissionPrecision { get; set; }
        public bool isMarginTradingAllowed { get; set; }

    }
}
