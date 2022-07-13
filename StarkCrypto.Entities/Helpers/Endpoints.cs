using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarkCrypto.Domains.Helpers
{
    public class Endpoints
    {
        public Endpoints()
        {
            Binance = new BinanceEndpoints();
            Bitfinex = new BitfinexEndpoints();
        }
        public BinanceEndpoints Binance { get; set; }
        public BitfinexEndpoints Bitfinex { get; set; }
    }

    public class BinanceEndpoints
    {
        public string ExchangeInfo { get; set; } = "https://api.binance.com/api/v3/exchangeInfo";
        public string TickerSymbols{ get; set; } = "https://api.binance.com/api/v3/ticker/24hr?symbols=";
        //public string TickerArray { get; set; } = "https://api.binance.com/api/v3/ticker?symbols=";
        public string OrderBookTicker { get; set; } = "https://api.binance.com/api/v3/ticker/bookTicker?symbols=";
        public string PriceTicker { get; set; } = "https://api.binance.com/api/v3/ticker/price?symbols=";
    }

    public class BitfinexEndpoints
    {
        public string PlatafomrStatus { get; set; } = "https://api-pub.bitfinex.com/v2/platform/status";
        public string Tickers { get; set; } = "https://api-pub.bitfinex.com/v2/tickers?symbols=";
        public string Ticker { get; set; } = "https://api-pub.bitfinex.com/v2/ticker/";
        public string GetCoins { get; set; } = "https://api-pub.bitfinex.com/v2/conf/pub:map:currency:label";
        public string OrderBookTicker { get; set; } = "https://api.binance.com/api/v3/ticker/bookTicker?symbols=";
        public string PriceTicker { get; set; } = "https://api.binance.com/api/v3/ticker/price?symbols=";
    }
}
