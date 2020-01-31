using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvide.Models
{
    public class Order : Base
    {
        [DisplayName("Descrption")]
        public String Descrption { get; set; }

        [Required(ErrorMessage = "This Filed Is Required")]
        [DisplayName("User Name")]
        public String ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        [Required(ErrorMessage = "This Filed Is Required")]
        [DisplayName("Service Provider Name")]
        public int ServiceProviderId { get; set; }
        [ForeignKey("ServiceProviderId")]
        public ServiceProvider ServiceProvider { get; set; }

        [Required(ErrorMessage = "This Filed Is Required")]
        [DisplayName("Order Time")]
        [DataType(DataType.DateTime)]
        public DateTime OrderTime { get; set; }


        [Required(ErrorMessage = "This Filed Is Required")]
        [DisplayName("Order Number")]
        public int OrderNumber { get; set; }


    }
}
