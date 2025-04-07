using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MCS.Models;

namespace MCS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteRequestsController : ControllerBase
    {
        private readonly McsdbContext _context;

        public QuoteRequestsController(McsdbContext context)
        {
            _context = context;
        }

        // GET: api/QuoteRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuoteRequest>>> GetQuoteRequests()
        {
            return await _context.QuoteRequests.ToListAsync();
        }

        // GET: api/QuoteRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuoteRequest>> GetQuoteRequest(string id)
        {
            var quoteRequest = await _context.QuoteRequests.FindAsync(id);

            if (quoteRequest == null)
            {
                return NotFound();
            }

            return quoteRequest;
        }

        // PUT: api/QuoteRequests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuoteRequest(string id, QuoteRequest quoteRequest)
        {
            if (id != quoteRequest.RequestId)
            {
                return BadRequest();
            }

            _context.Entry(quoteRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuoteRequestExists(id))
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

        // POST: api/QuoteRequests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QuoteRequest>> PostQuoteRequest(QuoteRequest quoteRequest)
        {
            _context.QuoteRequests.Add(quoteRequest);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (QuoteRequestExists(quoteRequest.RequestId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetQuoteRequest", new { id = quoteRequest.RequestId }, quoteRequest);
        }

        // DELETE: api/QuoteRequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuoteRequest(string id)
        {
            var quoteRequest = await _context.QuoteRequests.FindAsync(id);
            if (quoteRequest == null)
            {
                return NotFound();
            }

            _context.QuoteRequests.Remove(quoteRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuoteRequestExists(string id)
        {
            return _context.QuoteRequests.Any(e => e.RequestId == id);
        }
    }
}
