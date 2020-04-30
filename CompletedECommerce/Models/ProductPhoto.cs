using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class ProductPhoto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Provied photo.")]
        [DataType(DataType.ImageUrl)]
        public string Photo { get; set; }

        [Required(ErrorMessage = "Select product.")]
        public int ProductId { get; set; }
        public bool Status { get; set; }

        public Product Product { get; set; }
    }
}
