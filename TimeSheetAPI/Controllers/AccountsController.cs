using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeSheetAPI.Data;
using TimeSheetAPI.Helpers;
using TimeSheetAPI.Models;
using TimeSheetAPI.ViewModels;

namespace TimeSheetAPI.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly DBContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly IAccountHelper _accountHelper;

        public AccountsController(UserManager<User> userManager, DBContext dbContext, IAccountHelper accountHelper)
        {
            _accountHelper = accountHelper;
            _userManager = userManager;
            _dbContext = dbContext;
        }

        // POST api/accounts
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdentity = _accountHelper.GetUserFromRegistrationViewModel(model);

            var result = await _userManager.CreateAsync(userIdentity, model.Password);

            if (!result.Succeeded) return new BadRequestObjectResult(model);
            
            await _dbContext.Employees.AddAsync(new Employee { IdentityId = userIdentity.Id, Location = model.Location });
            await _dbContext.SaveChangesAsync();

            return new OkObjectResult("Account created");
        }
    }
}
