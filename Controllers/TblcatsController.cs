using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestPloomes.Model;

namespace TestPloomes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblcatsController : ControllerBase
    {
        private readonly catsdb _context;

        public TblcatsController(catsdb context)
        {
            _context = context;
        }

        // GET: api/Tblcats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tblcat>>> GetTblcats()
        {
            return await _context.Tblcats.ToListAsync();
        }

        // GET: api/Tblcats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tblcat>> GetTblcat(int id)
        {
            var tblcat = await _context.Tblcats.FindAsync(id);

            if (tblcat == null)
            {
                return NotFound();
            }

            return tblcat;
        }

        // PUT: api/Tblcats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblcat(int id, Tblcat tblcat)
        {
            if (id != tblcat.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblcat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblcatExists(id))
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

        // POST: api/Tblcats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tblcat>> PostTblcat(Tblcat tblcat)
        {
            _context.Tblcats.Add(tblcat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblcat", new { id = tblcat.Id }, tblcat);
        }

        // DELETE: api/Tblcats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblcat(int id)
        {
            var tblcat = await _context.Tblcats.FindAsync(id);
            if (tblcat == null)
            {
                return NotFound();
            }

            _context.Tblcats.Remove(tblcat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblcatExists(int id)
        {
            return _context.Tblcats.Any(e => e.Id == id);
        }
    }
}
