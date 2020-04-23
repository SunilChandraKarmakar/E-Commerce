using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Role
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Provied role name.")]
        [StringLength(20, MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Provied status.")]
        public bool Status { get; set; }

        public ICollection<RoleAccount> RoleAccounts { get; set; }
    }
}
