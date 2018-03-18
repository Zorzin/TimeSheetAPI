using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetAPI.Models;
using TimeSheetAPI.ViewModels;

namespace TimeSheetAPI.Helpers
{
    public class AccountHelper : IAccountHelper
    {
        public User GetUserFromRegistrationViewModel(RegistrationViewModel registrationViewModel)
        {
            return new User()
            {
                Email = registrationViewModel.Email,
                LastName = registrationViewModel.LastName,
                UserName = registrationViewModel.FirstName,
                PositionId = 1
            };
        }
    }

    public interface IAccountHelper
    {
        User GetUserFromRegistrationViewModel(RegistrationViewModel registrationViewModel);
    }
}
