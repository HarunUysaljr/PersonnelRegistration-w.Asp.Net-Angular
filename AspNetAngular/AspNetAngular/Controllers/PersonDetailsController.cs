using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspNetAngular.Models;

namespace AspNetAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonDetailsController : ControllerBase
    {
        private readonly PersonDetailContext _context;

        public PersonDetailsController(PersonDetailContext context)
        {
            _context = context;
        }

        // GET: api/PersonDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonDetails>>> GetPersonDetails()
        {
          if (_context.PersonDetails == null)
          {
              return NotFound();
          }
            return await _context.PersonDetails.ToListAsync();
        }

        // GET: api/PersonDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDetails>> GetPersonDetails(int id)
        {
          if (_context.PersonDetails == null)
          {
              return NotFound();
          }
            var personDetails = await _context.PersonDetails.FindAsync(id);

            if (personDetails == null)
            {
                return NotFound();
            }

            return personDetails;
        }

        // PUT: api/PersonDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonDetails(int id, PersonDetails personDetails)
        {
            if (id != personDetails.PerId)
            {
                return BadRequest();
            }

            _context.Entry(personDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonDetailsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(await _context.PersonDetails.ToListAsync());
        }

        // POST: api/PersonDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PersonDetails>> PostPersonDetails(PersonDetails personDetails)
        {
          if (_context.PersonDetails == null)
          {
              return Problem("Entity set 'PersonDetailContext.PersonDetails'  is null.");
          }
            _context.PersonDetails.Add(personDetails);
            await _context.SaveChangesAsync();

            return Ok(await _context.PersonDetails.ToListAsync());
        }

        // DELETE: api/PersonDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonDetails(int id)
        {
            if (_context.PersonDetails == null)
            {
                return NotFound();
            }
            var personDetails = await _context.PersonDetails.FindAsync(id);
            if (personDetails == null)
            {
                return NotFound();
            }

            _context.PersonDetails.Remove(personDetails);
            await _context.SaveChangesAsync();

            return Ok(await _context.PersonDetails.ToListAsync());
        }

        private bool PersonDetailsExists(int id)
        {
            return (_context.PersonDetails?.Any(e => e.PerId == id)).GetValueOrDefault();
        }
    }
}
