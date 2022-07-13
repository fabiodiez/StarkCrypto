using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using StarkCrypto.Domains.Enum;
using StarkCrypto.Domains.Helpers;
using StarkCrypto.Domains.Models;
using StarkCrypto.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Threading.Tasks;
using StarkCrypto.Domains.Receives;

namespace StarkCrypto.Services
{
    public class ConfigService : ControllerBase, IConfigService
    {
        public Endpoints _endpoint = new Endpoints();
        public ICoinService _coinService;
        public IPairService _pairService;

     
   
        public ConfigService(ICoinService coinService, IPairService pairService)
        {
            _coinService = coinService;
            _pairService = pairService;
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
                        await _coinService.Add(coin);
                    }

                    foreach (var pair in pairs)
                    {
                        await _pairService.Add(pair);
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
                       await _coinService.Edit(coinPersistence.Id, coinPersistence);
                    }
                    else
                    {
                       var coin = new Coin { SymbolBitfinex = symbol[0].ToString(), CoinName = symbol[1].ToString(), Status = true };
                       await  _coinService.Add(coin);
                    }

                    //coinsBitfinex.Add(new Pair { ExchangeId = (int)eExchanges.Binance, PairName = symbol.Symbol, FirstCoin = symbol.baseAsset, SecondCoin = symbol.quoteAsset, Status = true });
                
                }

                //foreach (var coin in coins)
                //{
                //    await _coinService.Add(coin);
                //}

                //foreach (var pair in pairs)
                //{
                //    await _pairService.Add(pair);
                //}

                #endregion

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Erro ao processar a solicitação" });
            }
        }
        
    }
}
