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
    [Route("v1/pairs")]
    public class PairsController : ControllerBase
    {
        readonly IPairService _service;

        /// <summary>
        /// Construtor da Coins
        /// </summary>
        /// <param name="service"></param>        
        public PairsController(IPairService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("")]
        //[Authorize]
        public async Task<ActionResult<List<Pair>>> Get() => await _service.Get();

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Pair>> GetById(int id) => await _service.GetById(id);
        
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Pair>> Post([FromBody] Pair model) => await _service.Add(model);

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Pair>> Put(int id,[FromBody] Pair model) => await _service.Edit(id, model);

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> Delete(int id) => await _service.Delete(id);        


    }
}
