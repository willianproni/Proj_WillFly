﻿using System;
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
    public class AeroportosController : ControllerBase
    {
        private readonly WillFlyContext _context;

        public AeroportosController(WillFlyContext context)
        {
            _context = context;
        }

        // GET: api/Aeroportos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aeroporto>>> GetAeroporto()
        {
            return await _context.Aeroporto.Include(endereco => endereco.Endereco).ToListAsync();
        }

        // GET: api/Aeroportos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aeroporto>> GetAeroporto(string id)
        {
            var aeroporto = await _context.Aeroporto.FindAsync(id);

            if (aeroporto == null)
            {
                return NotFound();
            }

            return aeroporto;
        }

        // PUT: api/Aeroportos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAeroporto(string id, Aeroporto aeroporto)
        {
            if (id != aeroporto.Sigla)
            {
                return BadRequest();
            }

            _context.Entry(aeroporto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AeroportoExists(id))
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

        // POST: api/Aeroportos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aeroporto>> PostAeroporto(Aeroporto aeroporto)
        {
            var endereco = await Service.CepApi.ViaCepJsonAsync(aeroporto.Endereco.Cep);
            aeroporto.Endereco.Localidade = endereco.Localidade;
            aeroporto.Endereco.Logradouro = endereco.Logradouro;
            aeroporto.Endereco.Uf = endereco.Uf;
            aeroporto.Endereco.Bairro = endereco.Bairro;
            aeroporto.Endereco.Complemento = endereco.Complemento;
            _context.Aeroporto.Add(aeroporto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AeroportoExists(aeroporto.Sigla))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAeroporto", new { id = aeroporto.Sigla }, aeroporto);
        }

        // DELETE: api/Aeroportos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAeroporto(string id)
        {
            var aeroporto = await _context.Aeroporto.FindAsync(id);
            if (aeroporto == null)
            {
                return NotFound();
            }

            _context.Aeroporto.Remove(aeroporto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AeroportoExists(string id)
        {
            return _context.Aeroporto.Any(e => e.Sigla == id);
        }
    }
}
