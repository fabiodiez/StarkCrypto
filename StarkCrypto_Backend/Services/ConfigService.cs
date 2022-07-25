using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarkCrypto.Data;
using StarkCrypto.Domains.Enum;
using StarkCrypto.Domains.Helpers;
using StarkCrypto.Domains.Models;
using StarkCrypto.Domains.Receives;
using StarkCrypto.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace StarkCrypto.Services
{
    public class ConfigService : ControllerBase, IConfigService
    {
        public Endpoints _endpoint = new Endpoints();
        readonly DataContext _context;
        public ICoinService _coinService;
        public IPairService _pairService;

        public ConfigService(ICoinService coinService, IPairService pairService, DataContext context)
        {
            _coinService = coinService;
            _pairService = pairService;
            _context = context;
        }

        public async Task<ActionResult<string>> GetAllCoins()
        { 
            try
            {
                #region Binance

                    var symbols = await new RequestService<BinanceSymbolsReceive>().GetAsync(_endpoint.Binance.ExchangeInfo);
                    var pairs = new List<Pair>();
                    var coins = new List<Coin>();
                    foreach (var symbol in symbols.Symbols.Where(c => c.isMarginTradingAllowed))
                    {
                        var coin = new Coin { Symbol = symbol.baseAsset, Status = true }; 
                        if(!coins.Any(c => c.Symbol.Equals(coin.Symbol))) coins.Add(coin);
                    
                        coin = new Coin { Symbol = symbol.quoteAsset, Status = true };                    
                        if (!coins.Any(c => c.Symbol.Equals(coin.Symbol))) coins.Add(coin);

                        pairs.Add(new Pair { ExchangeId = (int) eExchanges.Binance, PairName = symbol.Symbol, FirstCoin = symbol.baseAsset, SecondCoin = symbol.quoteAsset, Status = true });
                    
                    }

                    foreach (var coin in coins)
                    {
                        //await _coinService.Add(coin);
                    }

                    foreach (var pair in pairs)
                    {
                       // await _pairService.Add(pair);
                    }

                #endregion

                #region Bitfinex

                var symbolsBitfinex = await new RequestService<dynamic>().GetAsync(_endpoint.Bitfinex.GetCoins);
                var pairsBitfinex = new List<Pair>();
                var coinsBitfinex = new List<Coin>();

                foreach (var symbol in symbolsBitfinex[0])
                {
                    Coin coinPersistence = await _coinService.GetBySymbol(symbol[0].ToString());

                    if (coinPersistence != null)
                    {
                       coinPersistence.SymbolBitfinex = symbol[0].ToString();
                       coinPersistence.CoinName = symbol[1].ToString();
                       //await _coinService.Edit(coinPersistence.Id, coinPersistence);
                    }
                    else
                    {
                       var coin = new Coin { SymbolBitfinex = symbol[0].ToString(), CoinName = symbol[1].ToString(), Status = true };
                       //await  _coinService.Add(coin);
                    }

                     pairsBitfinex.Add(new Pair { ExchangeId = (int)eExchanges.Bitfinex, PairName = symbol.Symbol, FirstCoin = symbol.baseAsset, SecondCoin = symbol.quoteAsset, Status = true });
                
                }

                //foreach (var coin in coins)
                //{
                //    await _coinService.Add(coin);
                //}

                 foreach (var pair in pairs)
                 {
                     await _pairService.Add(pair);
                 }

                #endregion

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Erro ao processar a solicitação" });
            }
        }

        public async Task<ActionResult<string>> GetOrderBookBinance()
        {            
            var pairsList = await _pairService.GetPairs(eExchanges.Binance);
            var orderBook = await new RequestService<List<BinanceTicker24Receive>>().GetAsync(_endpoint.Binance.OrderBook + pairsList);

            return Ok(orderBook);
        }

        public async Task<ActionResult<string>> GetOrderBookBitfinex()
        {
            var pairsList = await _pairService.GetPairs(eExchanges.Bitfinex);
            var orderBook = await new RequestService<List<List<object>>>().GetAsync(_endpoint.Bitfinex.Tickers + pairsList);
            var orderBookMap = new List<BinanceTicker24Receive>();
           
            foreach(var item in orderBook)
            {
                var ticker = new BinanceTicker24Receive();
                
                if(item.Count > 11)
                {
                    ticker.symbol = item[0].ToString().Replace("t","").Replace("UST","USDT").Replace("ALG", "ALGO").Replace("MNA", "MANA").Replace("UDC", "USDC");
                    ticker.symbolBitfinex = item[0].ToString();
                    ticker.bidPrice = item[2].ToString().Replace(",", ".");
                    ticker.bidQty = item[4].ToString().Replace(",",".");
                    ticker.askPrice = item[5].ToString().Replace(",", ".");
                    ticker.askQty = item[7].ToString().Replace(",", ".");
                    ticker.priceChange = item[8].ToString().Replace(",", ".");
                    ticker.priceChangePercent = item[9].ToString().Replace(",", ".");
                    ticker.lastPrice = item[10].ToString().Replace(",", ".");
                    ticker.volume = item[11].ToString().Replace(",", ".");
                    ticker.highPrice = item[12].ToString().Replace(",", ".");
                    ticker.lowPrice = item[13].ToString().Replace(",", ".");
                }
                else
                {
                    ticker.symbol = item[0].ToString().Replace("t", "").Replace("UST", "USDT").Replace("ALG", "ALGO").Replace("MNA", "MANA").Replace("UDC", "USDC");
                    ticker.symbolBitfinex = item[0].ToString();
                    ticker.bidPrice = item[1].ToString().Replace(",", ".");
                    ticker.bidQty = item[2].ToString().Replace(",", ".");
                    ticker.askPrice = item[3].ToString().Replace(",", ".");
                    ticker.askQty = item[4].ToString().Replace(",", ".");
                    ticker.priceChange = item[5].ToString().Replace(",", ".");
                    ticker.priceChangePercent = item[6].ToString().Replace(",", ".");
                    ticker.lastPrice = item[7].ToString().Replace(",", ".");
                    ticker.volume = item[8].ToString().Replace(",", ".");
                    ticker.quoteVolume = item[8].ToString().Replace(",", ".");
                    ticker.highPrice = item[9].ToString().Replace(",", ".");
                    ticker.lowPrice = item[10].ToString().Replace(",", ".");
                }
                orderBookMap.Add(ticker);
            }
            
            return Ok(orderBookMap);
        }
    }
}
