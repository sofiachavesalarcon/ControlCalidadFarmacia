using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControlCalidadFarmacia.Context;
using ControlCalidadFarmacia.Model;

namespace ControlCalidadFarmacia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly pharmacyContext _context;

        public TestsController(pharmacyContext context)
        {
            _context = context;
        }

        // GET: api/Tests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tests>>> Gettests()
        {
            return await _context.tests.ToListAsync();
        }

        // GET: api/Tests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tests>> GetTests(int id)
        {
            var tests = await _context.tests.FindAsync(id);

            if (tests == null)
            {
                return NotFound();
            }

            return tests;
        }

        // PUT: api/Tests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTests(int id, Tests tests)
        {
            if (id != tests.TestId)
            {
                return BadRequest();
            }

            _context.Entry(tests).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestsExists(id))
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

        // POST: api/Tests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tests>> PostTests(Tests tests)
        {
            _context.tests.Add(tests);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTests", new { id = tests.TestId }, tests);
        }

        // DELETE: api/Tests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTests(int id)
        {
            var tests = await _context.tests.FindAsync(id);
            if (tests == null)
            {
                return NotFound();
            }

            _context.tests.Remove(tests);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TestsExists(int id)
        {
            return _context.tests.Any(e => e.TestId == id);
        }
    }
}
