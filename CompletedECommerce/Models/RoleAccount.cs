using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class RoleAccount
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Provied role.")]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "Provied account.")]
        public int AccountId { get; set; }

        [Required(ErrorMessage = "Provied status.")]
        public bool Status { get; set; }

        public Role Role { get; set; }
        public Account Account { get; set; }
    }
}
