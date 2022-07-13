using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using StarkCrypto.Domains.Enum;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace StarkCrypto.Services.Interfaces
{
    public interface IConfigService
    {
        Task<ActionResult<string>> GetAllCoins();
    }
}
