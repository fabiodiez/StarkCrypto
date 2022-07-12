using Microsoft.AspNetCore.Mvc;
using StarkCrypto.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarkCrypto.Services.Interfaces
{
    public interface ICoinService
    {
        Task<ActionResult<List<Coin>>> Get();
        Task<ActionResult<Coin>> GetById(int id);
        Task<ActionResult<Coin>> Add(Coin model);
        Task<ActionResult<Coin>> Edit(int id, Coin model);
        Task<ActionResult> Delete(int id);
    }
}
