using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TimeSheetAPI.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string BankAccountNumber { get; set; }
        public double Sallary { get; set; }
        public int PositionId { get; set; }
    }
}
