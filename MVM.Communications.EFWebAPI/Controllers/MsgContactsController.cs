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
    public class MsgContactsController : ControllerBase
    {
        private readonly MVMComunicationsDataContext _context;

        public MsgContactsController(MVMComunicationsDataContext context)
        {
            _context = context;
        }

        // GET: api/MsgContacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MsgContact>>> GetMsgContacts()
        {
            return await _context.MsgContacts.ToListAsync();
        }

        // GET: api/MsgContacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MsgContact>> GetMsgContact(int id)
        {
            var msgContact = await _context.MsgContacts.FindAsync(id);

            if (msgContact == null)
            {
                return NotFound();
            }

            return msgContact;
        }

        // PUT: api/MsgContacts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMsgContact(int id, MsgContact msgContact)
        {
            if (id != msgContact.Id)
            {
                return BadRequest();
            }

            _context.Entry(msgContact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MsgContactExists(id))
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

        // POST: api/MsgContacts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MsgContact>> PostMsgContact(MsgContact msgContact)
        {
            _context.MsgContacts.Add(msgContact);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMsgContact", new { id = msgContact.Id }, msgContact);
        }

        // DELETE: api/MsgContacts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MsgContact>> DeleteMsgContact(int id)
        {
            var msgContact = await _context.MsgContacts.FindAsync(id);
            if (msgContact == null)
            {
                return NotFound();
            }

            _context.MsgContacts.Remove(msgContact);
            await _context.SaveChangesAsync();

            return msgContact;
        }

        private bool MsgContactExists(int id)
        {
            return _context.MsgContacts.Any(e => e.Id == id);
        }
    }
}
