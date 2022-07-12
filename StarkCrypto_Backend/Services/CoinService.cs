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
    public class CoinService : ControllerBase, ICoinService
    {
        readonly DataContext _context;

        public CoinService(DataContext context) 
        {
            _context = context;
        }

        public async Task<ActionResult<List<Coin>>> Get()
        {
            try
            {
                var ret = await _context.Coins.ToListAsync();
                return Ok(ret);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Erro ao processar a solicitação" });
            }
        }

        public async Task<ActionResult<Coin>> GetById(int id)
        {
            try
            {
                var ret = await _context.Coins.Where(x => x.Id == id).FirstOrDefaultAsync();
                return Ok(ret);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Erro ao processar a solicitação" });
            }
        }

        public async Task<ActionResult<Coin>> Add(Coin model)
        {            
            _context.Coins.Add(model);
            await _context.SaveChangesAsync();
            
            try {
                var ret = await _context.Coins.Where(p => p.Id == model.Id).FirstOrDefaultAsync();
                return Ok(ret);            
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Erro ao Adicionar a Coin" });
            }
            
        }

        public async Task<ActionResult<Coin>> Edit(int id, Coin model)
        {
            if (model.Id != id)
                return NotFound(new { message = "Coin não encontrada" });

            _context.Coins.Add(model);
            try
            {
                await _context.SaveChangesAsync();
                var ret = await _context.Coins.Where(p => p.Id == model.Id).FirstOrDefaultAsync();
                return Ok(ret);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Erro ao Adicionar a Coin" });
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            var ret = await _context.Coins.FirstOrDefaultAsync(p => p.Id == id);

            if (ret == null)
                return NotFound(new { message = "Registro não encontrado" });

            try
            {
                _context.Coins.Remove(ret);
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
