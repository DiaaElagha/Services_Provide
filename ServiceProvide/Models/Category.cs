using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvide.Models
{
    public class Category : Base
    {
        [Required(ErrorMessage = "This Filed Is Required")]
        [DisplayName("Category Name")]
        public String Name { get; set; }
    }
}
