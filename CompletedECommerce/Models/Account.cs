using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Account
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Provied user name.")]
        [StringLength(20, MinimumLength = 2)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Provied full name.")]
        [StringLength(20, MinimumLength = 2)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Provied password.")]
        [StringLength(50, MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Provied confirm password.")]
        [StringLength(50, MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Provied email address.")]
        [StringLength(50, MinimumLength = 10)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Provied status.")]
        public bool Status { get; set; }

        public ICollection<RoleAccount> RoleAccounts { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}
