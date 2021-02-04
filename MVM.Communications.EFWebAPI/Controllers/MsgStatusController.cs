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
    public class MsgStatusController : ControllerBase
    {
        private readonly MVMComunicationsDataContext _context;

        public MsgStatusController(MVMComunicationsDataContext context)
        {
            _context = context;
        }

        // GET: api/MsgStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MsgStatus>>> GetMsgStatuses()
        {
            return await _context.MsgStatuses.ToListAsync();
        }

        // GET: api/MsgStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MsgStatus>> GetMsgStatus(int id)
        {
            var msgStatus = await _context.MsgStatuses.FindAsync(id);

            if (msgStatus == null)
            {
                return NotFound();
            }

            return msgStatus;
        }

        // PUT: api/MsgStatus/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMsgStatus(int id, MsgStatus msgStatus)
        {
            if (id != msgStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(msgStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MsgStatusExists(id))
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

        // POST: api/MsgStatus
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MsgStatus>> PostMsgStatus(MsgStatus msgStatus)
        {
            _context.MsgStatuses.Add(msgStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMsgStatus", new { id = msgStatus.Id }, msgStatus);
        }

        // DELETE: api/MsgStatus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MsgStatus>> DeleteMsgStatus(int id)
        {
            var msgStatus = await _context.MsgStatuses.FindAsync(id);
            if (msgStatus == null)
            {
                return NotFound();
            }

            _context.MsgStatuses.Remove(msgStatus);
            await _context.SaveChangesAsync();

            return msgStatus;
        }

        private bool MsgStatusExists(int id)
        {
            return _context.MsgStatuses.Any(e => e.Id == id);
        }
    }
}
