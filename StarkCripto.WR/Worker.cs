using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using StarkCrypto.Entities.Models;
using Binance.Client.Websocket.Subscriptions;
using Binance.Client.Websocket.Client;
using Binance.Client.Websocket.Websockets;
using Binance.Client.Websocket;
using StarkCrypto.Entities.Enum;
using StarkCrypto.Data;
using Microsoft.AspNetCore.Mvc;

namespace StarkCrypto.WR
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly DataContext _context;

    #region Variáveis BINANCE
        private ManualResetEvent exitEvent = new ManualResetEvent(false);
        private Uri url = BinanceValues.ApiWebsocketUrl;
        #endregion Variáveis BINANCE

        public Worker(ILogger<Worker> logger, [FromServices] DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await WebSocketBinance(); //WebSocket Binance

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(50000, stoppingToken);
            }
        }

        #region WebSocket Binance
        private async Task WebSocketBinance()
        {             
            using (var communicator = new BinanceWebsocketCommunicator(url))
                {
                 using  (var client = new BinanceWebsocketClient(communicator))
                    {
                        client.Streams.OrderBookDiffStream.Subscribe(response =>
                        {
                            var trade = response.Data;
                            var orderBook = new OrderBookBase {
                                                Ask = trade.Asks.First().Price,
                                                AskVolume = trade.Asks.First().Quantity,
                                                Bid = trade.Bids.First().Price,
                                                BidVolume =trade.Bids.First().Quantity,
                                                Coin = new Coin { Symbol = trade.Symbol},
                                                ExchangeId = (int) eExchanges.Binance,
                                                CreatedDate = DateTime.Now
                            };

                            //Salvar no Banco de dados espelho do Orderbook

                            //_context.OrderBooksBase.Add(orderBook);
                           // _context.SaveChanges();

                           Console.WriteLine(@$"SYMBOL: {trade.Symbol}" +
                                               $"\n ASK Price: {trade.Asks.First().Price} " +
                                               $" - ASK Volume: {trade.Asks.First().Quantity} " +
                                               $"\n BID Price: {trade.Bids.First().Price} " +
                                               $" - BID Volume: {trade.Bids.First().Quantity} " +
                                               $" - DateTime: {DateTime.Now} " +
                                               $"\n -----------------------------------------------------------------");

                        });

                        //Criar uma forma de adicionar todas os pares aqui
                        //Obter os Pares do Banco de Dados
                        client.SetSubscriptions(
                            new OrderBookDiffSubscription("btcusdt"),
                            new OrderBookDiffSubscription("ethusdt"),
                            new OrderBookDiffSubscription("bnbusdt"),
                            new OrderBookDiffSubscription("adausdt"),
                            new OrderBookDiffSubscription("xmrusdt"),
                            new OrderBookDiffSubscription("xrpusdt"),
                            new OrderBookDiffSubscription("vetusdt"),
                            new OrderBookDiffSubscription("algousdt"),
                            new OrderBookDiffSubscription("dogeusdt"),
                            new OrderBookDiffSubscription("bttusdt"),
                            new OrderBookDiffSubscription("zilusdt"),
                            new OrderBookDiffSubscription("dotusdt"),
                            new OrderBookDiffSubscription("omgusdt"),
                            new OrderBookDiffSubscription("iostusdt")
                            );

                        await communicator.Start();

                        exitEvent.WaitOne(TimeSpan.FromSeconds(1));
                    }
                }          
        }
        
        #endregion WebSocket Binance
    }
}
