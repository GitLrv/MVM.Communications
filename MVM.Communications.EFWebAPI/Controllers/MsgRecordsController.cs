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
    public class MsgRecordsController : ControllerBase
    {
        private readonly MVMComunicationsDataContext _context;

        public MsgRecordsController(MVMComunicationsDataContext context)
        {
            _context = context;
        }

        // GET: api/MsgRecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MsgRecord>>> GetMsgRecords()
        {
            return await _context.MsgRecords.ToListAsync();
        }

        // GET: api/MsgRecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MsgRecord>> GetMsgRecord(int id)
        {
            var msgRecord = await _context.MsgRecords.FindAsync(id);

            if (msgRecord == null)
            {
                return NotFound();
            }

            return msgRecord;
        }

        // PUT: api/MsgRecords/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMsgRecord(int id, MsgRecord msgRecord)
        {
            if (id != msgRecord.Id)
            {
                return BadRequest();
            }

            _context.Entry(msgRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MsgRecordExists(id))
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

        // POST: api/MsgRecords
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MsgRecord>> PostMsgRecord(MsgRecord msgRecord)
        {
            _context.MsgRecords.Add(msgRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMsgRecord", new { id = msgRecord.Id }, msgRecord);
        }

        // DELETE: api/MsgRecords/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MsgRecord>> DeleteMsgRecord(int id)
        {
            var msgRecord = await _context.MsgRecords.FindAsync(id);
            if (msgRecord == null)
            {
                return NotFound();
            }

            _context.MsgRecords.Remove(msgRecord);
            await _context.SaveChangesAsync();

            return msgRecord;
        }

        private bool MsgRecordExists(int id)
        {
            return _context.MsgRecords.Any(e => e.Id == id);
        }
    }
}
