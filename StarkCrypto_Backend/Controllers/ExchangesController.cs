using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarkCrypto.Services.Interfaces;
using StarkCrypto.Entities.Models;
using StarkCrypto.Data;

namespace StarkCrypto.Controllers
{
    [ApiController]
    [Route("v1/exchanges")]
    public class ExchangesController : ControllerBase
    {
        readonly IExchangeService _service;

        /// <summary>
        /// Construtor da Exchanges
        /// </summary>
        /// <param name="service"></param>        
        public ExchangesController(IExchangeService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("")]
        //[Authorize]
        public async Task<ActionResult<List<Exchange>>> Get() => await _service.Get();

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Exchange>> GetById(int id) => await _service.GetById(id);
        
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Exchange>> Post([FromBody] Exchange model) => await _service.Add(model);

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Exchange>> Put(int id,[FromBody] Exchange model) => await _service.Edit(id, model);

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> Delete(int id) => await _service.Delete(id);        


    }
}
