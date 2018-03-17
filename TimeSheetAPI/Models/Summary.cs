using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheetAPI.Models
{
    public class Summary
    {

        public int Id { get; set; }
        public TimeSpan TimeAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string UserId { get; set; }

        public Summary(int id, TimeSpan timeAmount, DateTime startDate, DateTime endDate, string userId)
        {
            Id = id;
            TimeAmount = timeAmount;
            StartDate = startDate;
            EndDate = endDate;
            UserId = userId;
        }
    }
}
