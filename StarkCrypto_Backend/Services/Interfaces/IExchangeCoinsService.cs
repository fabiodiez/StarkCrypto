using Microsoft.AspNetCore.Mvc;
using StarkCrypto.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarkCrypto.Services.Interfaces
{
    public interface IExchangeCoinsService
    {
        Task<ActionResult<List<ExchangeCoin>>> Get();
        Task<ActionResult<ExchangeCoin>> GetById(int id);
        Task<ActionResult<ExchangeCoin>> Add(ExchangeCoin model);
        Task<ActionResult<ExchangeCoin>> Edit(int id, ExchangeCoin model);
        Task<ActionResult> Delete(int id);
    }
}
