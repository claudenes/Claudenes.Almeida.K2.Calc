using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Claudenes.Almeida.K2.Calc.Models;

namespace Claudenes.Almeida.K2.Calc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {
        private readonly TodoContext _context;

        public CalculaJurosController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/CalculaJuros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CalculaJuros>>> GetCalculaJuros()
        {
            return await _context.CalculaJuros.ToListAsync();
        }

        // GET: api/CalculaJuros/5
        [HttpGet, Route("CalculaJuros/{valorInicial:decimal}/{quantidadeMeses:int}")]
        public async Task<ActionResult<CalculaJuros>> GetCalculaJuros(decimal valorInicial, int quantidadeMeses)
        {

            TaxaJurosController tx = new TaxaJurosController(_context);
            var potencia = (decimal)Math.Pow(1 + ((double)0.01M), quantidadeMeses);
            var valorCheio = Convert.ToDecimal(valorInicial * potencia);
            var valorCalculado = Math.Round(valorCheio, 2);

            if (valorCalculado == null)
            {
                return NotFound();
            }

            return Ok(valorCalculado);
        }

        // PUT: api/CalculaJuros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalculaJuros(long id, CalculaJuros calculaJuros)
        {
            if (id != calculaJuros.Id)
            {
                return BadRequest();
            }

            _context.Entry(calculaJuros).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalculaJurosExists(id))
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

        // POST: api/CalculaJuros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CalculaJuros>> PostCalculaJuros(CalculaJuros calculaJuros)
        {
            _context.CalculaJuros.Add(calculaJuros);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCalculaJuros", new { id = calculaJuros.Id }, calculaJuros);
        }

        // DELETE: api/CalculaJuros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalculaJuros(long id)
        {
            var calculaJuros = await _context.CalculaJuros.FindAsync(id);
            if (calculaJuros == null)
            {
                return NotFound();
            }

            _context.CalculaJuros.Remove(calculaJuros);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CalculaJurosExists(long id)
        {
            return _context.CalculaJuros.Any(e => e.Id == id);
        }
        /// <summary>
        /// Show me the code
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("showmethecode")]
        public async Task<IActionResult> ShowMeTheCode()
        {
            return Ok("https://github.com/claudenes/Claudenes.Almeida.K2.Calc");
        } 
    }
    

    

}
