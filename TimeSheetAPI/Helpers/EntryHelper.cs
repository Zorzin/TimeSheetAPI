using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimeSheetAPI.Data;
using TimeSheetAPI.Models;

namespace TimeSheetAPI.Helpers
{
    public class EntryHelper : IEntryHelper
    {
        private readonly DBContext _dbContext;

        public EntryHelper(DBContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public bool DateContainsEntry(DateTime date)
        {
            return _dbContext.Entries.Any(e => e.Date == date);
        }

        public IEnumerable<Entry> GetEntriesBetweenDates(string userId, DateTime startDate, DateTime endDate)
        {
            return _dbContext.Entries.Where(e => e.Date >= startDate && e.Date <= endDate && e.UserId == userId);
        }

        public async Task<Entry> GetEntryForDate(string userId, DateTime date)
        {
            return await _dbContext.Entries.FirstOrDefaultAsync(e => e.Date.Date == date.Date && e.UserId == userId);
        }
    }

    public interface IEntryHelper
    {
        bool DateContainsEntry(DateTime date);
        IEnumerable<Entry> GetEntriesBetweenDates(string userId, DateTime startDate, DateTime endDate);
        Task<Entry> GetEntryForDate(string userId, DateTime date);
    }
}
