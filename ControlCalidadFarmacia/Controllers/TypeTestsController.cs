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
    public class TypeTestsController : ControllerBase
    {
        private readonly pharmacyContext _context;

        public TypeTestsController(pharmacyContext context)
        {
            _context = context;
        }

        // GET: api/TypeTests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeTest>>> GettypeTests()
        {
            return await _context.typeTests.ToListAsync();
        }

        // GET: api/TypeTests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeTest>> GetTypeTest(int id)
        {
            var typeTest = await _context.typeTests.FindAsync(id);

            if (typeTest == null)
            {
                return NotFound();
            }

            return typeTest;
        }

        // PUT: api/TypeTests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeTest(int id, TypeTest typeTest)
        {
            if (id != typeTest.TypeId)
            {
                return BadRequest();
            }

            _context.Entry(typeTest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeTestExists(id))
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

        // POST: api/TypeTests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TypeTest>> PostTypeTest(TypeTest typeTest)
        {
            _context.typeTests.Add(typeTest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypeTest", new { id = typeTest.TypeId }, typeTest);
        }

        // DELETE: api/TypeTests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeTest(int id)
        {
            var typeTest = await _context.typeTests.FindAsync(id);
            if (typeTest == null)
            {
                return NotFound();
            }

            _context.typeTests.Remove(typeTest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypeTestExists(int id)
        {
            return _context.typeTests.Any(e => e.TypeId == id);
        }
    }
}
