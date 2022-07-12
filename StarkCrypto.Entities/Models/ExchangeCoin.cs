using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StarkCrypto.Entities.Models
{
    public class ExchangeCoin
    {
        [Key]
        public int Id { get; set; }
        public int ExchangeId { get; set; }
        public virtual Exchange Exchange { get; set; }
        public int CoinId { get; set; }
        public virtual Coin Coin { get; set; }
        public string Address{ get; set; }        
        public string Tag { get; set; }
        public bool Status { get; set; }
    }
}
