using Microsoft.AspNetCore.Mvc;
using StarkCrypto.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarkCrypto.Services.Interfaces
{
    public interface IPairService
    {
        Task<ActionResult<List<Pair>>> Get();
        Task<ActionResult<Pair>> GetById(int id);
        Task<ActionResult<Pair>> Add(Pair model);
        Task<ActionResult<Pair>> Edit(int id, Pair model);
        Task<ActionResult> Delete(int id);
    }
}
