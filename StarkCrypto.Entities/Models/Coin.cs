using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StarkCrypto.Entities.Models
{
    public class Coin
    {
        [Key]
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string CoinName { get; set; }
        public string SymbolBitfinex { get; set; }
        public bool Status { get; set; }
    }
}
