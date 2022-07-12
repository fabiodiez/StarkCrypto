using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarkCrypto.Data;
using StarkCrypto.Domains.Models;
using StarkCrypto.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarkCrypto.Services
{
    public class ExchangeCoinsService : ControllerBase, IExchangeCoinsService
    {
        readonly DataContext _context;

        public ExchangeCoinsService(DataContext context) 
        {
            _context = context;
        }

        public async Task<ActionResult<List<ExchangeCoin>>> Get()
        {
            try
            {
                var ret = await _context.ExchangeCoins.Include("Exchange").Include("Coin").AsNoTracking().ToListAsync();
                return Ok(ret);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Erro ao processar a solicitação" });
            }
        }

        public async Task<ActionResult<ExchangeCoin>> GetById(int id)
        {
            try
            {
                var ret = await _context.ExchangeCoins.Include("Exchange").Include("Coin").AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
                return Ok(ret);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Erro ao processar a solicitação" });
            }
        }

        public async Task<ActionResult<ExchangeCoin>> Add(ExchangeCoin model)
        {            
            _context.ExchangeCoins.Add(model);
            await _context.SaveChangesAsync();
            
            try {
                var ret = await _context.ExchangeCoins.Where(p => p.Id == model.Id).Include("Exchange").Include("Coin").AsNoTracking().FirstOrDefaultAsync();
                return Ok(ret);            
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Erro ao Adicionar a ExchangeCoin" });
            }
            
        }

        public async Task<ActionResult<ExchangeCoin>> Edit(int id, ExchangeCoin model)
        {
            if (model.Id != id)
                return NotFound(new { message = "ExchangeCoin não encontrada" });

            _context.ExchangeCoins.Add(model);
            try
            {
                await _context.SaveChangesAsync();
                var ret = await _context.ExchangeCoins.Where(p => p.Id == model.Id).Include("Exchange").Include("Coin").AsNoTracking().FirstOrDefaultAsync();
                return Ok(ret);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Erro ao Adicionar a ExchangeCoin" });
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            var ret = await _context.ExchangeCoins.FirstOrDefaultAsync(p => p.Id == id);

            if (ret == null)
                return NotFound(new { message = "Registro não encontrado" });

            try
            {
                _context.ExchangeCoins.Remove(ret);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Registro removido com sucesso" });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível Remover o Registro." });
            }
        }
    }
}
