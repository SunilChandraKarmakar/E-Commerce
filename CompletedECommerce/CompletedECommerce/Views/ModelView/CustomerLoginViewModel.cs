using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompletedECommerce.Views.ModelView
{
    public class CustomerLoginViewModel
    {
        [Required(ErrorMessage = "Provied user name.")]
        [StringLength(20, MinimumLength = 2)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Provied password.")]
        [StringLength(50, MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
