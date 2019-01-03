using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EksamenAPI.Data;
using EksamenAPI.Models;

namespace EksamenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpgavesController : ControllerBase
    {
        private readonly ModelContext _context;

        public OpgavesController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/Opgaves
        [HttpGet]
        public IEnumerable<Opgave> GetOpgaver()
        {
            return _context.Opgaver;
        }

        // GET: api/Opgaves/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOpgave([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var opgave = await _context.Opgaver.FindAsync(id);

            if (opgave == null)
            {
                return NotFound();
            }

            return Ok(opgave);
        }

        // PUT: api/Opgaves/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOpgave([FromRoute] int id, [FromBody] Opgave opgave)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != opgave.OpgaveId)
            {
                return BadRequest();
            }

            _context.Entry(opgave).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OpgaveExists(id))
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

        // POST: api/Opgaves
        [HttpPost]
        public async Task<IActionResult> PostOpgave([FromBody] Opgave opgave)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Opgaver.Add(opgave);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOpgave", new { id = opgave.OpgaveId }, opgave);
        }

        // DELETE: api/Opgaves/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOpgave([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var opgave = await _context.Opgaver.FindAsync(id);
            if (opgave == null)
            {
                return NotFound();
            }

            _context.Opgaver.Remove(opgave);
            await _context.SaveChangesAsync();

            return Ok(opgave);
        }

        private bool OpgaveExists(int id)
        {
            return _context.Opgaver.Any(e => e.OpgaveId == id);
        }
    }
}