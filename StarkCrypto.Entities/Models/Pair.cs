using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StarkCrypto.Domains.Models
{
    public class Pair
    {
        [Key]
        public int Id { get; set; }
        public int ExchangeId { get; set; }
        public virtual Exchange Exchange { get; set; }
        public string PairName { get; set; }
        public int FirstCoinId { get; set; }
        public virtual Coin FirstCoin { get; set; }
        public int SecondCoinId { get; set; }
        public virtual Coin SecondCoin { get; set; }
        public bool Status { get; set; }
    }
}
