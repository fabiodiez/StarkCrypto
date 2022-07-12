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
    [Route("v1/opportunities")]
    public class OpportunitiesController : ControllerBase
    {
        readonly IOpportunityService _service;

        /// <summary>
        /// Construtor da Opportunitys
        /// </summary>
        /// <param name="service"></param>        
        public OpportunitiesController(IOpportunityService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("")]
        //[Authorize]
        public async Task<ActionResult<List<Opportunity>>> Get() => await _service.Get();

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Opportunity>> GetById(int id) => await _service.GetById(id);
        
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Opportunity>> Post([FromBody] Opportunity model) => await _service.Add(model);

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Opportunity>> Put(int id,[FromBody] Opportunity model) => await _service.Edit(id, model);

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> Delete(int id) => await _service.Delete(id);        


    }
}
