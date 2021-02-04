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
    public class ConsecutiveControlsController : ControllerBase
    {
        private readonly MVMComunicationsDataContext _context;

        public ConsecutiveControlsController(MVMComunicationsDataContext context)
        {
            _context = context;
        }

        // GET: api/ConsecutiveControls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsecutiveControl>>> GetConsecutiveControls()
        {
            return await _context.ConsecutiveControls.ToListAsync();
        }

        // GET: api/ConsecutiveControls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConsecutiveControl>> GetConsecutiveControl(int id)
        {
            var consecutiveControl = await _context.ConsecutiveControls.FindAsync(id);

            if (consecutiveControl == null)
            {
                return NotFound();
            }

            return consecutiveControl;
        }

        // PUT: api/ConsecutiveControls/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsecutiveControl(int id, ConsecutiveControl consecutiveControl)
        {
            if (id != consecutiveControl.Id)
            {
                return BadRequest();
            }

            _context.Entry(consecutiveControl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsecutiveControlExists(id))
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

        // POST: api/ConsecutiveControls
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ConsecutiveControl>> PostConsecutiveControl(ConsecutiveControl consecutiveControl)
        {
            _context.ConsecutiveControls.Add(consecutiveControl);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConsecutiveControl", new { id = consecutiveControl.Id }, consecutiveControl);
        }

        // DELETE: api/ConsecutiveControls/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ConsecutiveControl>> DeleteConsecutiveControl(int id)
        {
            var consecutiveControl = await _context.ConsecutiveControls.FindAsync(id);
            if (consecutiveControl == null)
            {
                return NotFound();
            }

            _context.ConsecutiveControls.Remove(consecutiveControl);
            await _context.SaveChangesAsync();

            return consecutiveControl;
        }

        private bool ConsecutiveControlExists(int id)
        {
            return _context.ConsecutiveControls.Any(e => e.Id == id);
        }
    }
}
