using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceProvide.Data;
using ServiceProvide.Models;

namespace ServiceProvide.Controllers
{
    [Authorize(Roles = "cc")]
    public class ValuesController : BaseController
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public ValuesController(UserManager<ApplicationUser> userManager, ApplicationDbContext context , RoleManager<IdentityRole> roleManager) : base(userManager, context)
        {
            _roleManager = roleManager;
        }
        public async Task<IActionResult> CreateRoles()
        {

            IdentityResult result2 = await _roleManager.CreateAsync(new IdentityRole("Admin"));
            IdentityResult result3 = await _roleManager.CreateAsync(new IdentityRole("Provider"));
            IdentityResult result1 = await _roleManager.CreateAsync(new IdentityRole("User"));

            if (result1.Succeeded && result2.Succeeded && result3.Succeeded)
            {
                return new JsonResult("Done");
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Initlize()
        {
            // Initlize Users Types
            List<UserType> UserType = new List<UserType>();
            UserType.Add(new UserType
            {
                Name = "Admin",
            });
            UserType.Add(new UserType
            {
                Name = "Provider",
            });
            UserType.Add(new UserType
            {
                Name = "User",
            });
            foreach (var x in UserType)
            {
                _context.Add(x);
            }
            await _context.SaveChangesAsync();
            return new JsonResult("Done");
        }

    }
}