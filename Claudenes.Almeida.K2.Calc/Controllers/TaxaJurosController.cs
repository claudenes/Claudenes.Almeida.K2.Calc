using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Claudenes.Almeida.K2.Calc.Models;
using Claudenes.Almeida.K2.Calc.Interface;

namespace Claudenes.Almeida.K2.Calc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxaJurosController : ControllerBase
    {

        #region Private members
        private readonly iTaxaJuros _taxa;
        #endregion
        private readonly TodoContext _context;

        public TaxaJurosController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/TaxaJuros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaxaJuros>>> GetTaxaJuros()
        {

            var result = 0.01M;
            return Ok(result);
          //  return await _context.TaxaJuros.ToListAsync();
        }

        // GET: api/TaxaJuros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaxaJuros>> GetTaxaJuros(long id)
        {


            var taxaJuros = await _context.TaxaJuros.FindAsync(id);

            if (taxaJuros == null)
            {
                return NotFound();
            }

            return taxaJuros;
        }

        // PUT: api/TaxaJuros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaxaJuros(long id, TaxaJuros taxaJuros)
        {
            if (id != taxaJuros.Id)
            {
                return BadRequest();
            }

            _context.Entry(taxaJuros).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaxaJurosExists(id))
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

        // POST: api/TaxaJuros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaxaJuros>> PostTaxaJuros(TaxaJuros taxaJuros)
        {
            _context.TaxaJuros.Add(taxaJuros);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaxaJuros", new { id = taxaJuros.Id }, taxaJuros);
        }

        // DELETE: api/TaxaJuros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaxaJuros(long id)
        {
            var taxaJuros = await _context.TaxaJuros.FindAsync(id);
            if (taxaJuros == null)
            {
                return NotFound();
            }

            _context.TaxaJuros.Remove(taxaJuros);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaxaJurosExists(long id)
        {
            return _context.TaxaJuros.Any(e => e.Id == id);
        }
    }
}
