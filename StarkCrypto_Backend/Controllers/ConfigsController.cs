using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarkCrypto.Services.Interfaces;
using StarkCrypto.Domains.Models;
using StarkCrypto.Data;
using StarkCrypto.Domains.Enum;

namespace StarkCrypto.Controllers
{
    [ApiController]
    [Route("v1/Configs")]
    public class ConfigsController : ControllerBase
    {
        readonly IConfigService _service;

        /// <summary>
        /// Construtor da Coins
        /// </summary>
        /// <param name="service"></param>        
        public ConfigsController(IConfigService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("/GetAllCoins")]
        //[Authorize]
        public async Task<ActionResult<string>> GetAllCoins() => await _service.GetAllCoins();

        //[HttpGet]
        //[Route("/GetAllPairs")]
        ////[Authorize]
        //public async Task<ActionResult<string>> GetAllPairs(int exchange) => await _service.GetAllPairs(exchange);

    }
}
