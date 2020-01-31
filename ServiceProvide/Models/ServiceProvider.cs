using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvide.Models
{
    public class ServiceProvider : Base
    {
        [Required(ErrorMessage = "This Filed Is Required")]
        [DisplayName("Service Name")]
        public int ServiceId { get; set; }
        [ForeignKey("ServiceId")]
        public Service Service { get; set; }

        [Required(ErrorMessage = "This Filed Is Required")]
        [DisplayName("Provider Name")]
        public String ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
