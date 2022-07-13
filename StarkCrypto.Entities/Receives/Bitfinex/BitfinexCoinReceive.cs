using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarkCrypto.Domains.Receives
{
    public class BitfinexCoinReceive
    {
        public List<List<List<namesymbol>>> NomeSymbol { get; set; }
    }

    public class namesymbol
    {
       public string name { get; set; }
       public string value { get; set; }
    }
}
