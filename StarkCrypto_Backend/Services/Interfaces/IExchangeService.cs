using Microsoft.AspNetCore.Mvc;
using StarkCrypto.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarkCrypto.Services.Interfaces
{
    public interface IExchangeService
    {
        Task<ActionResult<List<Exchange>>> Get();
        Task<ActionResult<Exchange>> GetById(int id);
        Task<ActionResult<Exchange>> Add(Exchange model);
        Task<ActionResult<Exchange>> Edit(int id, Exchange model);
        Task<ActionResult> Delete(int id);
    }
}
