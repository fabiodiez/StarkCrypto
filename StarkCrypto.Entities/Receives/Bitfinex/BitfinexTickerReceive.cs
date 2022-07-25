using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarkCrypto.Domains.Receives
{
    public class BitfinexTickerReceive
    {
        public List<BitfinexTicker> BitfinexTicker { get; set; }
    }

    public class BitfinexTicker
    {
       public string SYMBOL { get; set; }
       public float FRR { get; set; }
       public float BID { get; set; }
       public float BID_PERIOD { get; set; }
       public float BID_SIZE { get; set; }
       public float ASK { get; set; }
       public float ASK_PERIOD { get; set; }
       public float ASK_SIZE { get; set; }
       public float DAILY_CHANGE { get; set; }
       public float DAILY_CHANGE_RELATIVE { get; set; }
       public float LAST_PRICE { get; set; }
       public float VOLUME { get; set; }
       public float HIGH { get; set; }
       public float LOW { get; set; }
       public float FRR_AMOUNT_AVAILABLE { get; set; }
    }
}
