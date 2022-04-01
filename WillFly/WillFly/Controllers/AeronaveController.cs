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
    public class AeronaveController : ControllerBase
    {
        private readonly WillFlyContext _context;

        public AeronaveController(WillFlyContext context)
        {
            _context = context;
        }

        // GET: api/Aeronave
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aeronave>>> GetAeronave()
        {
            return await _context.Aeronave.ToListAsync();
        }

        // GET: api/Aeronave/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aeronave>> GetAeronave(int id)
        {
            var aeronave = await _context.Aeronave.FindAsync(id);

            if (aeronave == null)
            {
                return NotFound();
            }

            return aeronave;
        }

        // PUT: api/Aeronave/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAeronave(int id, Aeronave aeronave)
        {
            if (id != aeronave.Id)
            {
                return BadRequest();
            }

            _context.Entry(aeronave).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AeronaveExists(id))
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

        // POST: api/Aeronave
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aeronave>> PostAeronave(Aeronave aeronave)
        {
            _context.Aeronave.Add(aeronave);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAeronave", new { id = aeronave.Id }, aeronave);
        }

        // DELETE: api/Aeronave/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAeronave(int id)
        {
            var aeronave = await _context.Aeronave.FindAsync(id);
            if (aeronave == null)
            {
                return NotFound();
            }

            _context.Aeronave.Remove(aeronave);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AeronaveExists(int id)
        {
            return _context.Aeronave.Any(e => e.Id == id);
        }
    }
}
