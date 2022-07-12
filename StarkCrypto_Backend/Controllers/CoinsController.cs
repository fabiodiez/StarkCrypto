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
    [Route("v1/coins")]
    public class CoinsController : ControllerBase
    {
        readonly ICoinService _service;

        /// <summary>
        /// Construtor da Coins
        /// </summary>
        /// <param name="service"></param>        
        public CoinsController(ICoinService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("")]
        //[Authorize]
        public async Task<ActionResult<List<Coin>>> Get() => await _service.Get();

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Coin>> GetById(int id) => await _service.GetById(id);
        
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Coin>> Post([FromBody] Coin model) => await _service.Add(model);

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Coin>> Put(int id,[FromBody] Coin model) => await _service.Edit(id, model);

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> Delete(int id) => await _service.Delete(id);        


    }
}
