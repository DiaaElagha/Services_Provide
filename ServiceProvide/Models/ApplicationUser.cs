using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvide.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public String FullName { get; set; }

        [Required]
        public int UserTypeId { get; set; }
        public UserType UserType { get; set; }


    }
}
