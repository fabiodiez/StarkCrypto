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
    public class ExchangeService : ControllerBase, IExchangeService
    {
        readonly DataContext _context;

        public ExchangeService(DataContext context) 
        {
            _context = context;
        }

        public async Task<ActionResult<List<Exchange>>> Get()
        {
            try
            {
                var ret = await _context.Exchanges.ToListAsync();
                return Ok(ret);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Erro ao processar a solicitação" });
            }
        }

        public async Task<ActionResult<Exchange>> GetById(int id)
        {
            try
            {
                var ret = await _context.Exchanges.Where(x => x.Id == id).FirstOrDefaultAsync();
                return Ok(ret);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Erro ao processar a solicitação" });
            }
        }

        public async Task<ActionResult<Exchange>> Add(Exchange model)
        {            
            _context.Exchanges.Add(model);
            await _context.SaveChangesAsync();
            
            try {
                var ret = await _context.Exchanges.Where(p => p.Id == model.Id).FirstOrDefaultAsync();
                return Ok(ret);            
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Erro ao Adicionar a Exchange" });
            }
            
        }

        public async Task<ActionResult<Exchange>> Edit(int id, Exchange model)
        {
            if (model.Id != id)
                return NotFound(new { message = "Exchange não encontrada" });

            _context.Exchanges.Add(model);
            try
            {
                await _context.SaveChangesAsync();
                var ret = await _context.Exchanges.Where(p => p.Id == model.Id).FirstOrDefaultAsync();
                return Ok(ret);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Erro ao Adicionar a Exchange" });
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            var ret = await _context.Exchanges.FirstOrDefaultAsync(p => p.Id == id);

            if (ret == null)
                return NotFound(new { message = "Registro não encontrado" });

            try
            {
                _context.Exchanges.Remove(ret);
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
