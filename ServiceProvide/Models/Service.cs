using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvide.Models
{
    public class Service : Base
    {
        [Required(ErrorMessage = "This Filed Is Required")]
        [DisplayName("Service Name")]
        public String Name { get; set; }

        [Required(ErrorMessage = "This Filed Is Required")]
        [DisplayName("Service Descrption")]
        public String Descrption { get; set; }

        [Required(ErrorMessage = "This Filed Is Required")]
        [DisplayName("Service Price")]
        public float Price { get; set; }

        [Required(ErrorMessage = "This Filed Is Required")]
        [DisplayName("Category Name")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

    }
}
