using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Meister.SDK.Identity.NetCore.Data;
using Meister.SDK.Identity.NetCore.Models;

namespace Meister.SDK.Identity.NetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeisterConnectionsController : ControllerBase
    {
        private readonly CompanyContext _context;

        public MeisterConnectionsController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/MeisterConnections
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MeisterConnection>>> GetMeisterConnection()
        {
            return await _context.MeisterConnection.ToListAsync();
        }

        // GET: api/MeisterConnections/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MeisterConnection>> GetMeisterConnection(long id)
        {
            var meisterConnection = await _context.MeisterConnection.FindAsync(id);

            if (meisterConnection == null)
            {
                return NotFound();
            }

            return meisterConnection;
        }

        // PUT: api/MeisterConnections/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeisterConnection(long id, MeisterConnection meisterConnection)
        {
            if (id != meisterConnection.Id)
            {
                return BadRequest();
            }

            _context.Entry(meisterConnection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeisterConnectionExists(id))
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

        // POST: api/MeisterConnections
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MeisterConnection>> PostMeisterConnection(MeisterConnection meisterConnection)
        {
            _context.MeisterConnection.Add(meisterConnection);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMeisterConnection", new { id = meisterConnection.Id }, meisterConnection);
        }

        // DELETE: api/MeisterConnections/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MeisterConnection>> DeleteMeisterConnection(long id)
        {
            var meisterConnection = await _context.MeisterConnection.FindAsync(id);
            if (meisterConnection == null)
            {
                return NotFound();
            }

            _context.MeisterConnection.Remove(meisterConnection);
            await _context.SaveChangesAsync();

            return meisterConnection;
        }

        private bool MeisterConnectionExists(long id)
        {
            return _context.MeisterConnection.Any(e => e.Id == id);
        }
    }
}
