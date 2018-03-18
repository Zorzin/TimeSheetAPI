using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheetAPI.Models
{
    public class EntrySummary
    {
        public int EntryId { get; set; }
        public int SummaryId { get; set; }
        public Entry Entry { get; set; }
        public Summary Summary { get; set; }
    }
}
