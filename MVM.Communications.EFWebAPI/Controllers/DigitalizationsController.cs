using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVM.Communications.EFWebAPI.Models;

namespace MVM.Communications.EFWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DigitalizationsController : ControllerBase
    {
        private readonly MVMComunicationsDataContext _context;

        public DigitalizationsController(MVMComunicationsDataContext context)
        {
            _context = context;
        }

        // GET: api/Digitalizations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Digitalization>>> GetDigitalizations()
        {
            return await _context.Digitalizations.ToListAsync();
        }

        // GET: api/Digitalizations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Digitalization>> GetDigitalization(int id)
        {
            var digitalization = await _context.Digitalizations.FindAsync(id);

            if (digitalization == null)
            {
                return NotFound();
            }

            return digitalization;
        }

        // PUT: api/Digitalizations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDigitalization(int id, Digitalization digitalization)
        {
            if (id != digitalization.Id)
            {
                return BadRequest();
            }

            _context.Entry(digitalization).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DigitalizationExists(id))
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

        // POST: api/Digitalizations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Digitalization>> PostDigitalization(Digitalization digitalization)
        {
            _context.Digitalizations.Add(digitalization);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDigitalization", new { id = digitalization.Id }, digitalization);
        }

        // DELETE: api/Digitalizations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Digitalization>> DeleteDigitalization(int id)
        {
            var digitalization = await _context.Digitalizations.FindAsync(id);
            if (digitalization == null)
            {
                return NotFound();
            }

            _context.Digitalizations.Remove(digitalization);
            await _context.SaveChangesAsync();

            return digitalization;
        }

        private bool DigitalizationExists(int id)
        {
            return _context.Digitalizations.Any(e => e.Id == id);
        }
    }
}
