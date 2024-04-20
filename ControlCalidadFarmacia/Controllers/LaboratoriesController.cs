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
    public class LaboratoriesController : ControllerBase
    {
        private readonly pharmacyContext _context;

        public LaboratoriesController(pharmacyContext context)
        {
            _context = context;
        }

        // GET: api/Laboratories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Laboratory>>> Getlaboratorys()
        {
            return await _context.laboratorys.ToListAsync();
        }

        // GET: api/Laboratories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Laboratory>> GetLaboratory(int id)
        {
            var laboratory = await _context.laboratorys.FindAsync(id);

            if (laboratory == null)
            {
                return NotFound();
            }

            return laboratory;
        }

        // PUT: api/Laboratories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLaboratory(int id, Laboratory laboratory)
        {
            if (id != laboratory.LaboratoryId)
            {
                return BadRequest();
            }

            _context.Entry(laboratory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LaboratoryExists(id))
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

        // POST: api/Laboratories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Laboratory>> PostLaboratory(Laboratory laboratory)
        {
            _context.laboratorys.Add(laboratory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLaboratory", new { id = laboratory.LaboratoryId }, laboratory);
        }

        // DELETE: api/Laboratories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLaboratory(int id)
        {
            var laboratory = await _context.laboratorys.FindAsync(id);
            if (laboratory == null)
            {
                return NotFound();
            }

            _context.laboratorys.Remove(laboratory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LaboratoryExists(int id)
        {
            return _context.laboratorys.Any(e => e.LaboratoryId == id);
        }
    }
}
