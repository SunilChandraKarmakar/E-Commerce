using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompletedECommerce.Views.ModelView
{
    public class ProductPhotoModelView
    {
        [DataType(DataType.ImageUrl)]
        public string Photo { get; set; }

        [Required(ErrorMessage = "Select product.")]
        public int ProductId { get; set; }
        public bool Status { get; set; }
        public bool Featured { get; set; }
    }
}
