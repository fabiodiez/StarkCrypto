using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StarkCrypto.Domains.Models
{
    public class Exchange
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }
        public string Email { get; set; }
        public double Tax { get; set; }
        public bool Status { get; set; }
    }
}
