using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarkCrypto.Services.Interfaces;
using StarkCrypto.Entities.Models;
using StarkCrypto.Entities.Enum;
using StarkCrypto.Data;

namespace StarkCrypto.Controllers
{
    [ApiController]
    [Route("v1/initialSettings")]
    public class InitialSettingsController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<dynamic>> Get([FromServices] DataContext context)
        {

            try
            {
                var exchanges = await context.Exchanges.ToListAsync();
                if (exchanges.Count != 0)
                {
                    return BadRequest(new
                    {
                        message = "Configuração Inicial já realizada"
                    });
                }

                var exchange = new Exchange
                {
                    Name = "Binance",
                    Tax =  0.20,
                    Status = true

                };

                var exchange2 = new Exchange
                {
                    Name = "Bitfinex",
                    Tax = 0.20,
                    Status = true

                };

                var usuarioPadrao = new User { Name = "fabio", Email = "fabio@stark.com", Password = "st@rk", CellPhone = "62992616406", Cpf = "03321272111", Perfil = ePerfil.Administrador };

                #region coin
                var coins = new List<Coin>();
                coins.Add(new Coin
                {
                    CoinName = "Bitcoin",
                    Symbol = "BTC",
                    Status = true
                });

                coins.Add(new Coin
                {
                    CoinName = "Litecoin",
                    Symbol = "LTC",
                    Status = true
                });

                coins.Add(new Coin
                {
                    CoinName = "Tether",
                    Symbol = "USDT",
                    SymbolBitfinex = "UST",
                    Status = true
                });

                coins.Add(new Coin
                {
                    CoinName = "Cardano",
                    Symbol = "ADA",
                    Status = true
                });

                coins.Add(new Coin
                {
                    CoinName = "Monero",
                    Symbol = "XMR",
                    Status = true
                });

                coins.Add(new Coin
                {
                    CoinName = "Ethereum",
                    Symbol = "ETH",
                    Status = true
                });
                #endregion coin

                #region ExchangeCoin
                var exchangeCoins = new List<ExchangeCoin>();
                exchangeCoins.Add(new ExchangeCoin
                {
                    CoinId = 1,
                    ExchangeId = 1,
                    Status = true                    
                });

                exchangeCoins.Add(new ExchangeCoin
                {
                    CoinId = 2,
                    ExchangeId = 1,
                    Status = true
                });

                exchangeCoins.Add(new ExchangeCoin
                {
                    CoinId = 3,
                    ExchangeId = 1,
                    Status = true
                });

                exchangeCoins.Add(new ExchangeCoin
                {
                    CoinId = 4,
                    ExchangeId = 1,
                    Status = true
                });

                exchangeCoins.Add(new ExchangeCoin
                {
                    CoinId = 5,
                    ExchangeId = 1,
                    Status = true
                });

                exchangeCoins.Add(new ExchangeCoin
                {
                    CoinId = 6,
                    ExchangeId = 1,
                    Status = true
                });

                //Bitfinex
                exchangeCoins.Add(new ExchangeCoin
                {
                    CoinId = 1,
                    ExchangeId = 2,
                    Status = true
                });

                exchangeCoins.Add(new ExchangeCoin
                {
                    CoinId = 2,
                    ExchangeId = 2,
                    Status = true
                });

                exchangeCoins.Add(new ExchangeCoin
                {
                    CoinId = 3,
                    ExchangeId = 2,
                    Status = true
                });

                exchangeCoins.Add(new ExchangeCoin
                {
                    CoinId = 4,
                    ExchangeId = 2,
                    Status = true
                });

                exchangeCoins.Add(new ExchangeCoin
                {
                    CoinId = 5,
                    ExchangeId = 2,
                    Status = true
                });

                exchangeCoins.Add(new ExchangeCoin
                {
                    CoinId = 6,
                    ExchangeId = 2,
                    Status = true
                });
                #endregion ExchangeCoin

                #region pairs
                var pairs = new List<Pair>();
                pairs.Add(new Pair
                {

                    ExchangeId = 1,
                    FirstCoinId = 3,
                    SecondCoinId = 1
                });

                pairs.Add(new Pair
                {
                    ExchangeId = 2,
                    FirstCoinId = 3,
                    SecondCoinId = 1
                });

                pairs.Add(new Pair
                {
                    ExchangeId = 1,
                    FirstCoinId = 3,
                    SecondCoinId = 2
                });
                pairs.Add(new Pair
                {
                    ExchangeId = 2,
                    FirstCoinId = 3,
                    SecondCoinId = 2
                });
                #endregion Pairs

                context.Exchanges.Add(exchange);
                context.Exchanges.Add(exchange2);
                context.SaveChanges();
                
                context.Coins.AddRange(coins);
                context.SaveChanges();
                
                context.ExchangeCoins.AddRange(exchangeCoins);
                context.SaveChanges();
                
                context.Pairs.AddRange(pairs);
                context.SaveChanges();

                context.Users.Add(usuarioPadrao);
                context.SaveChanges();

                return Ok(new
                {
                    message = "Dados configurados"
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    message = "Ocorreu um Erro ao processar a requisição"
                });
            }
        }
    }
}
