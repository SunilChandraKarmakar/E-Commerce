using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Provied category name.")]
        [StringLength(20, MinimumLength = 2)]
        public string Name { get; set; }

        [Display(Name = "Parent Category")]
        public int? CategoryId { get; set; }
        public bool Status { get; set; }

        public Category Categorye { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
