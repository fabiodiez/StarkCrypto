using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarkCrypto.Entities.Models
{
    public class OrderBookPair
    {
        public int Id { get; set; }
        public int ExchangeId { get; set; }
        public Exchange Exchange { get; set; }
        public List<OBPair> Pairs { get; set; }
    }

    public class OBPair
    {
        public int PairId { get; set; }
        public string PairName { get; set; }
        public int ParId { get; set; }
        public Pair Pair { get; set; }
        public int FirstCoinId { get; set; }
        public Coin FirstCoin { get; set; }
        public int SecondCoinId { get; set; }
        public Coin SecondCoin { get; set; }
        public double Price { get; set; }
        public double PriceAsk { get; set; } //Venda
        public double PriceBid { get; set; } //Compra
        public double AvgPriceAsk5Min { get; set; } //Media Venda 5Min
        public double AvgPriceBid5Min { get; set; } //Media Compra 5Min
        public double AvgPriceAsk10Min { get; set; } //Media Venda 10Min
        public double AvgPriceBid10Min { get; set; } //Media Compra 10Min
        public double AvgPriceAsk15Min { get; set; } //Media Venda 15Min
        public double AvgPriceBid15Min { get; set; } //Media Compra 15Min
        public double AvgPriceAsk30Min { get; set; } //Media Venda 30Min
        public double AvgPriceBid30Min { get; set; } //Media Compra 30Min
        public double AvgPriceAsk60Min { get; set; } //Media Venda 60Min
        public double AvgPriceBid60Min { get; set; } //Media Compra 60Min
        public double VolumeAsk { get; set; }
        public double VolumeBid { get; set; }
        public TimeSpan DataHora { get; set; } //DataHora

    }
}
