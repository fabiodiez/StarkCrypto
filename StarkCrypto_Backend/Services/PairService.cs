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
    public class PairService : ControllerBase, IPairService
    {
        readonly DataContext _context;

        public PairService(DataContext context) 
        {
            _context = context;
        }

        public async Task<ActionResult<List<Pair>>> Get()
        {
            try
            {
                var ret = await _context.Pairs.Include(x => x.Exchange).Include(x => x.FirstCoin).Include(x => x.SecondCoin).AsNoTracking().ToListAsync();
                return Ok(ret);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Erro ao processar a solicitação" });
            }
        }

        public async Task<ActionResult<Pair>> GetById(int id)
        {
            try
            {
                var ret = await _context.Pairs.Include(x => x.Exchange).Include(x => x.FirstCoin).Include(x => x.SecondCoin).AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
                return Ok(ret);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Erro ao processar a solicitação" });
            }
        }

        public async Task<ActionResult<Pair>> Add(Pair model)
        {            
            _context.Pairs.Add(model);
            await _context.SaveChangesAsync();
            
            try {
                //var ret = await _context.Pairs.Where(p => p.Id == model.Id).Include(x => x.Exchange).Include(x => x.FirstCoin).Include(x => x.SecondCoin).AsNoTracking().FirstOrDefaultAsync();
                var ret = await _context.Pairs.Where(p => p.Id == model.Id).Include(x => x.Exchange).AsNoTracking().FirstOrDefaultAsync();
                return Ok(ret);            
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Erro ao Adicionar a Pair" });
            }
            
        }

        public async Task<ActionResult<Pair>> Edit(int id, Pair model)
        {
            if (model.Id != id)
                return NotFound(new { message = "Pair não encontrada" });

            _context.Pairs.Add(model);
            try
            {
                await _context.SaveChangesAsync();
                var ret = await _context.Pairs.Where(p => p.Id == model.Id).Include(x => x.Exchange).Include(x => x.FirstCoin).Include(x => x.SecondCoin).AsNoTracking().FirstOrDefaultAsync();
                return Ok(ret);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Erro ao Adicionar a Pair" });
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            var ret = await _context.Pairs.FirstOrDefaultAsync(p => p.Id == id);

            if (ret == null)
                return NotFound(new { message = "Registro não encontrado" });

            try
            {
                _context.Pairs.Remove(ret);
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
