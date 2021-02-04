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
    public class MsgTypesController : ControllerBase
    {
        private readonly MVMComunicationsDataContext _context;

        public MsgTypesController(MVMComunicationsDataContext context)
        {
            _context = context;
        }

        // GET: api/MsgTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MsgType>>> GetMsgTypes()
        {
            return await _context.MsgTypes.ToListAsync();
        }

        // GET: api/MsgTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MsgType>> GetMsgType(int id)
        {
            var msgType = await _context.MsgTypes.FindAsync(id);

            if (msgType == null)
            {
                return NotFound();
            }

            return msgType;
        }

        // PUT: api/MsgTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMsgType(int id, MsgType msgType)
        {
            if (id != msgType.Id)
            {
                return BadRequest();
            }

            _context.Entry(msgType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MsgTypeExists(id))
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

        // POST: api/MsgTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MsgType>> PostMsgType(MsgType msgType)
        {
            _context.MsgTypes.Add(msgType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMsgType", new { id = msgType.Id }, msgType);
        }

        // DELETE: api/MsgTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MsgType>> DeleteMsgType(int id)
        {
            var msgType = await _context.MsgTypes.FindAsync(id);
            if (msgType == null)
            {
                return NotFound();
            }

            _context.MsgTypes.Remove(msgType);
            await _context.SaveChangesAsync();

            return msgType;
        }

        private bool MsgTypeExists(int id)
        {
            return _context.MsgTypes.Any(e => e.Id == id);
        }
    }
}
