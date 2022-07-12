using Microsoft.AspNetCore.Mvc;
using StarkCrypto.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarkCrypto.Services.Interfaces
{
    public interface IOpportunityService
    {
        Task<ActionResult<List<Opportunity>>> Get();
        Task<ActionResult<Opportunity>> GetById(int id);
        Task<ActionResult<Opportunity>> Add(Opportunity model);
        Task<ActionResult<Opportunity>> Edit(int id, Opportunity model);
        Task<ActionResult> Delete(int id);
    }
}
