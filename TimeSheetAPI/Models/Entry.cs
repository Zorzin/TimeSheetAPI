using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheetAPI.Models
{
    public class Entry
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public TimeSpan OutsideTime { get; set; }
        public string Type { get; set; }
        public bool AllDay { get; set; }
        public string UserId { get; set; }

        public Entry(int id, DateTime date, TimeSpan startTime, TimeSpan endTime, TimeSpan outsideTime, string type, bool allDay, string userId)
        {
            Id = id;
            Date = date;
            StartTime = startTime;
            EndTime = endTime;
            OutsideTime = outsideTime;
            Type = type;
            AllDay = allDay;
            UserId = userId;
        }
    }
}
