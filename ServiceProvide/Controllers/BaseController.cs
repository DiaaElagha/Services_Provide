using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ServiceProvide.Data;
using ServiceProvide.Models;

namespace ServiceProvide.Controllers
{
    public class BaseController : Controller
    {
        protected readonly UserManager<ApplicationUser> _userManager;
        protected readonly ApplicationDbContext _context;
        protected String UserId;
        protected String UserName;
        protected int UserTypeId;
        public BaseController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (User.Identity.IsAuthenticated)
            {
                base.OnActionExecuting(context);
                try
                {
                    UserId = _userManager.GetUserId(HttpContext.User);
                    ApplicationUser user = _context.Users.Find(UserId);
                    UserTypeId = user.UserTypeId;
                    UserName = user.FullName;
                    ViewBag.UserType = user.UserTypeId;
                    ViewBag.UserEmail = user.Email;
                    ViewBag.FullName = user.FullName;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }


    }
}