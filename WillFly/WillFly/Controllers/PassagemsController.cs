using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WillFly.Data;
using WillFly.Model;

namespace WillFly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassagemsController : ControllerBase
    {
        private readonly WillFlyContext _context;

        public PassagemsController(WillFlyContext context)
        {
            _context = context;
        }

        // GET: api/Passagems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Passagem>>> GetPassagem()
        {
            return await _context.Passagem
                .Include(vooOrigem => vooOrigem.Compra.Voo.Origem.Endereco)
                .Include(vooDestino => vooDestino.Compra.Voo.Destino.Endereco)
                .Include(vooAeronave => vooAeronave.Compra.Voo.Aeronave)        
                .Include(classe => classe.Compra.Classe)
                .Include(passageiro => passageiro.Passageiro.Endereco)
                .ToListAsync();
        }

        // GET: api/Passagems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Passagem>> GetPassagem(int id)
        {
            var passagem = await _context.Passagem
                .Include(compra => compra.Compra)
                .Include(passageiro => passageiro.Passageiro.Endereco)
                .Include(origem => origem.Compra.Voo.Origem.Endereco)
                .Include(destino => destino.Compra.Voo.Destino.Endereco)
                .Include(classe => classe.Compra.Classe)
                .Include(aeronave => aeronave.Compra.Voo.Aeronave)
                .Where(compra => compra.Id == id)
                .FirstOrDefaultAsync();

            if (passagem == null)
            {
                return NotFound();
            }

            return passagem;
        }

        // PUT: api/Passagems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPassagem(int id, Passagem passagem)
        {
            if (id != passagem.Id)
            {
                return BadRequest();
            }

            _context.Entry(passagem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassagemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Passagems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Passagem>> PostPassagem(Passagem passagem)
        {
            var cpfPassageiro = await _context.Passageiro.Where(p => p.Cpf == passagem.Passageiro.Cpf).FirstOrDefaultAsync();
            var compra = await _context.PrecoBase.Where(compra => compra.Id == passagem.Compra.Id).FirstOrDefaultAsync();
            //var compraVoo = await _context.PrecoBase.Where(compra => compra.Voo.Id == passagem.Compra.Voo.Id).FirstOrDefaultAsync();
            //var voo = await _context.PrecoBase.Where(voo => voo.Voo == passagem.Compra.Voo).FirstOrDefaultAsync();
            //var precoPassagem = await _context.PrecoBase.Where(valor => valor.ValorTotal == passagem.Compra.ValorTotal).FirstOrDefaultAsync();
            //var classe = await _context.PrecoBase.Where(classe => classe.Classe.Id == passagem.Compra.Classe.Id).FirstOrDefaultAsync();
            //passagem.Compra.Classe = classe.Classe;
            //passagem.Compra.Voo = voo.Voo;
            //passagem.Compra.Valor = precoPassagem.ValorTotal;
            passagem.Compra.Voo = compra.Voo;
            passagem.Compra.Classe = compra.Classe;
            passagem.Compra.Valor = compra.ValorTotal;
            passagem.Compra = compra;
            passagem.Passageiro = cpfPassageiro;
            _context.Passagem.Add(passagem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPassagem", new { id = passagem.Id }, passagem);
        }

        // DELETE: api/Passagems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassagem(int id)
        {
            var passagem = await _context.Passagem.FindAsync(id);
            if (passagem == null)
            {
                return NotFound();
            }

            _context.Passagem.Remove(passagem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PassagemExists(int id)
        {
            return _context.Passagem.Any(e => e.Id == id);
        }
    }
}
