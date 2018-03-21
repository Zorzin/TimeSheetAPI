using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeSheetAPI.Data;
using TimeSheetAPI.Helpers;
using TimeSheetAPI.Models;

namespace TimeSheetAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Entries")]
    public class EntriesController : Controller
    {
        private readonly DBContext _context;
        private readonly IEntryHelper _entryHelper;

        public EntriesController(DBContext context, IEntryHelper entryHelper)
        {
            _context = context;
            _entryHelper = entryHelper;
        }

        // GET: api/Entries
        [HttpGet]
        public IEnumerable<Entry> GetEntries()
        {
            return _context.Entries;
        }

        // GET: api/Entries
        [HttpGet]
        public IEnumerable<Entry> GetEntries(DateTime startDate, DateTime endDate)
        {
            return _entryHelper.GetEntriesBetweenDates(startDate,endDate);
        }

        // GET: api/Entries/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntry([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entry = await _context.Entries.SingleOrDefaultAsync(m => m.Id == id);

            if (entry == null)
            {
                return NotFound();
            }

            return Ok(entry);
        }

        // PUT: api/Entries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntry([FromRoute] int id, [FromBody] Entry entry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entry.Id)
            {
                return BadRequest();
            }

            _context.Entry(entry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntryExists(id))
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

        // POST: api/Entries
        [HttpPost]
        public async Task<IActionResult> PostEntry([FromBody] Entry entry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_entryHelper.DateContainsEntry(entry.Date))
            {
                return BadRequest(entry);
            }

            try
            {
                _context.Entries.Add(entry);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return CreatedAtAction("GetEntry", new { id = entry.Id }, entry);
        }

        // DELETE: api/Entries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntry([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entry = await _context.Entries.SingleOrDefaultAsync(m => m.Id == id);
            if (entry == null)
            {
                return NotFound();
            }

            _context.Entries.Remove(entry);
            await _context.SaveChangesAsync();

            return Ok(entry);
        }

        private bool EntryExists(int id)
        {
            return _context.Entries.Any(e => e.Id == id);
        }
    }
}