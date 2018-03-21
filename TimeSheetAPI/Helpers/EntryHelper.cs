using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public IEnumerable<Entry> GetEntriesBetweenDates(DateTime startDate, DateTime endDate)
        {
            return _dbContext.Entries.Where(e => e.Date >= startDate && e.Date <= endDate);
        }
    }

    public interface IEntryHelper
    {
        bool DateContainsEntry(DateTime date);
        IEnumerable<Entry> GetEntriesBetweenDates(DateTime startDate, DateTime endDate);
    }
}
