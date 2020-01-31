using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ServiceProvide.Models;

namespace ServiceProvide.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Category { set; get; }
        public DbSet<Order> Order { set; get; }
        public DbSet<Service> Service { set; get; }
        public DbSet<ServiceProvider> ServiceProvider { set; get; }
        public DbSet<UserType> UserType { set; get; }


    }
}
