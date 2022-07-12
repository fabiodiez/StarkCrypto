using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StarkCrypto.Entities.Models
{
    public class OrderBookBase
    {
        [Key]
        public int Id { get; set; }
        public int ExchangeId { get; set; }
        public virtual Exchange Exchange { get; set; }
        public int CoinId { get; set; }
        public virtual Coin Coin { get; set; }
        public  double Ask { get; set; }
        public  double Bid { get; set; }
        public double AskVolume { get; set; }
        public  double BidVolume { get; set; }
        public double AvgAsk5Min { get; set; }
        public double AvgAsk10Min { get; set; }
        public double AvgAsk15Min { get; set; }
        public double AvgAsk20Min { get; set; }
        public double AvgAsk30Min { get; set; }
        public double AvgAsk60Min { get; set; }
        public double AvgBid5Min { get; set; }
        public double AvgBid10Min { get; set; }
        public double AvgBid15Min { get; set; }
        public double AvgBid20Min { get; set; }
        public double AvgBid30Min { get; set; }
        public double AvgBid60Min { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}