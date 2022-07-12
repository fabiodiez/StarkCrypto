using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarkCrypto.Data;
using StarkCrypto.Entities.Models;
using StarkCrypto.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarkCrypto.Services
{
    public class OpportunityService : ControllerBase, IOpportunityService
    {
        readonly DataContext _context;

        public OpportunityService(DataContext context) 
        {
            _context = context;
        }

        public async Task<ActionResult<List<Opportunity>>> Get()
        {
            try
            {
                var ret = await _context.Opportunities
                                .Include(x => x.FirstExchange)
                                .Include(x => x.SecondExchange)
                                .Include(x => x.FirstCoin)
                                .Include(x=> x.SecondCoin).AsNoTracking()
                                .ToListAsync();
                return Ok(ret);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Erro ao processar a solicitação" });
            }
        }

        public async Task<ActionResult<Opportunity>> GetById(int id)
        {
            try
            {
                var ret = await _context.Opportunities
                                .Include(x => x.FirstExchange)
                                .Include(x => x.SecondExchange)
                                .Include(x => x.FirstCoin)
                                .Include(x => x.SecondCoin).AsNoTracking()
                                .Where(x => x.Id == id).FirstOrDefaultAsync();
                return Ok(ret);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Erro ao processar a solicitação" });
            }
        }

        public async Task<ActionResult<Opportunity>> Add(Opportunity model)
        {            
            _context.Opportunities.Add(model);
            await _context.SaveChangesAsync();
            
            try {
                var ret = await _context.Opportunities
                                 .Where(p => p.Id == model.Id)
                                .Include(x => x.FirstExchange)
                                .Include(x => x.SecondExchange)
                                .Include(x => x.FirstCoin)
                                .Include(x => x.SecondCoin).AsNoTracking()
                                .FirstOrDefaultAsync();
                return Ok(ret);            
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Erro ao Adicionar a Opportunity" });
            }
            
        }

        public async Task<ActionResult<Opportunity>> Edit(int id, Opportunity model)
        {
            if (model.Id != id)
                return NotFound(new { message = "Opportunity não encontrada" });

            _context.Opportunities.Add(model);
            try
            {
                await _context.SaveChangesAsync();
                var ret = await _context.Opportunities
                                .Where(p => p.Id == model.Id)
                                .Include(x => x.FirstExchange)
                                .Include(x => x.SecondExchange)
                                .Include(x => x.FirstCoin)
                                .Include(x => x.SecondCoin).AsNoTracking()
                                .FirstOrDefaultAsync();
                return Ok(ret);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Erro ao Adicionar a Opportunity" });
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            var ret = await _context.Opportunities.FirstOrDefaultAsync(p => p.Id == id);

            if (ret == null)
                return NotFound(new { message = "Registro não encontrado" });

            try
            {
                _context.Opportunities.Remove(ret);
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
