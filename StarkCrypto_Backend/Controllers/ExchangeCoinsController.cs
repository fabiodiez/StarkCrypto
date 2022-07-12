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

namespace StarkCrypto.Controllers
{
    [ApiController]
    [Route("v1/exchange-coins")]
    public class ExchangeCoinsController : ControllerBase
    {
        readonly IExchangeCoinsService _service;

        /// <summary>
        /// Construtor da Coins
        /// </summary>
        /// <param name="service"></param>        
        public ExchangeCoinsController(IExchangeCoinsService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("")]
        //[Authorize]
        public async Task<ActionResult<List<ExchangeCoin>>> Get() => await _service.Get();

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<ExchangeCoin>> GetById(int id) => await _service.GetById(id);
        
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<ExchangeCoin>> Post([FromBody] ExchangeCoin model) => await _service.Add(model);

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<ExchangeCoin>> Put(int id,[FromBody] ExchangeCoin model) => await _service.Edit(id, model);

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> Delete(int id) => await _service.Delete(id);        


    }
}
