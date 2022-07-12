using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StarkCrypto.Domains.Models
{
    public class Opportunity
    {
        [Key]
        public int Id { get; set; }
        public int OrderBookId { get; set; }        
        public int FirstExchangeId { get; set; }
        public virtual Exchange FirstExchange { get; set; }
        public int FirstCoinId { get; set; }
        public virtual Coin FirstCoin { get; set; }
        public double FirstSpread { get; set; }
        public int SecondExchangeId { get; set; }
        public virtual Exchange SecondExchange { get; set; }
        public int SecondCoinId { get; set; }
        public virtual Coin SecondCoin { get; set; }
        public double SecondSpread { get; set; }
        public double Profit { get; set; }
        public DateTime CreatedDate { get; set; }
    }
} 