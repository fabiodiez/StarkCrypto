using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarkCrypto.Domains.Models
{
    public class SimulationMirror
    {
        public int Id { get; set; }
        public int OrderBookId { get; set; }        
        public int ExchangeId { get; set; }
        public  Exchange Exchange { get; set; }
        public int FirstCoinId { get; set; }
        public Coin FirstCoin { get; set; }
        public double FirstCoinBid { get; set; }
        public double FirstCoinAsk { get; set; }
        public double FirstCoinAskAvg { get; set; }
        public double FirstCoinBidAvg { get; set; }
        public double FirstCoinTax { get; set; }
        public double FirstCoinWithdrawlfee { get; set; }
        public double FirstCoinIncremental { get; set; }        
        public int SecondCoinId { get; set; }
        public Coin SecondCoin { get; set; }
        public double SecondCoinBid { get; set; }
        public double SecondCoinAsk { get; set; }
        public double SecondCoinAskAvg { get; set; }
        public double SecondCoinBidAvg { get; set; }
        public double SecondCoinTax { get; set; }
        public double SecondCoinWithdrawlfee { get; set; }
        public double SecondCoinIncremental { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}  