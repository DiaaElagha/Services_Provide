using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceProvide.Data;
using ServiceProvide.Models;

namespace ServiceProvide.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AccountsController : BaseController
    {
        public AccountsController(UserManager<ApplicationUser> userManager, ApplicationDbContext context) : base(userManager, context)
        {
        }
        public async Task<IActionResult> IndexPrviders()
        {

            var providers = await _context.Users.Where(x => x.UserTypeId == 2).ToListAsync();
            return View(providers);
        }

        public async Task<IActionResult> IndexUsers()
        {
            var providers = await _context.Users.Where(x => x.UserTypeId == 3).ToListAsync();
            return View(providers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                user.UserTypeId = 2;
                user.UserName = user.Email;
                var result = await _userManager.CreateAsync(user, "Userdb11$");
                if (result.Succeeded)
                {
                    IdentityResult identityResult = await _userManager.AddToRoleAsync(user, "Provider");
                    return RedirectToAction(nameof(IndexPrviders));
                }
            }
            return View(user);
        }


    }
}