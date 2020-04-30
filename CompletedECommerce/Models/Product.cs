using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Provied product name.")]
        [StringLength(20, MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Select category.")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Provied price.")]
        [DataType(DataType.Currency)]
        public float Price { get; set; }

        [Required(ErrorMessage = "Provied quantity.")]
        [DataType(DataType.PhoneNumber)]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Provied details of product.")]
        [DataType(DataType.MultilineText)]
        public string Details { get; set; }

        [Required(ErrorMessage = "Provied description of product.")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public bool Featured { get; set; }
        public bool Status { get; set; }

        public Category Category { get; set; }
        public ICollection<ProductPhoto> ProductPhotos { get; set; }
    }
}
