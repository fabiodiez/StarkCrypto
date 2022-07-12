using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarkCrypto.Domains.Models;

namespace StarkCrypto.Data
{
    public class DataContext : DbContext
    {      
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
            public DbSet<Exchange> Exchanges { get; set; }
            public DbSet<Coin> Coins { get; set; }
            public DbSet<ExchangeCoin> ExchangeCoins { get; set; }
            public DbSet<Pair> Pairs { get; set; }
            public DbSet<User> Users { get; set; }
            public DbSet<OrderBookBase> OrderBooksBase { get; set; }        
            public DbSet<Opportunity> Opportunities { get; set; }        

    }
     
}
   

 