using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServiceProvide.Data;
using ServiceProvide.Models;

namespace ServiceProvide.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ServiceProvidersController : BaseController
    {
        public ServiceProvidersController(UserManager<ApplicationUser> userManager, ApplicationDbContext context) : base(userManager, context)
        {
        }

        // GET: ServiceProviders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ServiceProvider.Include(s => s.ApplicationUser).Include(s => s.Service);
          
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ServiceProviders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceProvider = await _context.ServiceProvider
                .Include(s => s.ApplicationUser)
                .Include(s => s.Service)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviceProvider == null)
            {
                return NotFound();
            }

            return View(serviceProvider);
        }

        // GET: ServiceProviders/Create
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.Users.Where(x => x.UserTypeId == 2), "Id", "FullName");
            ViewData["ServiceId"] = new SelectList(_context.Service, "Id", "Name");
            return View();
        }

        // POST: ServiceProviders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiceId,ApplicationUserId,Id")] ServiceProvider serviceProvider)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviceProvider);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", serviceProvider.ApplicationUserId);
            ViewData["ServiceId"] = new SelectList(_context.Service, "Id", "Descrption", serviceProvider.ServiceId);
            return View(serviceProvider);
        }

        // GET: ServiceProviders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceProvider = await _context.ServiceProvider.FindAsync(id);
            if (serviceProvider == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", serviceProvider.ApplicationUserId);
            ViewData["ServiceId"] = new SelectList(_context.Service, "Id", "Descrption", serviceProvider.ServiceId);
            return View(serviceProvider);
        }

        // POST: ServiceProviders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServiceId,ApplicationUserId,Id")] ServiceProvider serviceProvider)
        {
            if (id != serviceProvider.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceProvider);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceProviderExists(serviceProvider.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", serviceProvider.ApplicationUserId);
            ViewData["ServiceId"] = new SelectList(_context.Service, "Id", "Descrption", serviceProvider.ServiceId);
            return View(serviceProvider);
        }

        // GET: ServiceProviders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceProvider = await _context.ServiceProvider
                .Include(s => s.ApplicationUser)
                .Include(s => s.Service)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviceProvider == null)
            {
                return NotFound();
            }

            return View(serviceProvider);
        }

        // POST: ServiceProviders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var serviceProvider = await _context.ServiceProvider.FindAsync(id);
            _context.ServiceProvider.Remove(serviceProvider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceProviderExists(int id)
        {
            return _context.ServiceProvider.Any(e => e.Id == id);
        }
    }
}
