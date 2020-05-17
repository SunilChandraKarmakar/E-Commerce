using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class InvoiceDetails
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Select Invoice")]
        public int InvoiceId { get; set; }

        [Required(ErrorMessage = "Select Product")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Provied Price")]
        [DataType(DataType.Currency)]
        public float Price { get; set; }

        [Required(ErrorMessage = "Provied Quantity")]
        [DataType(DataType.PhoneNumber)]
        public int Quantity { get; set; }

        public Invoice Invoice { get; set; }
        public Product Product { get; set; }
    }
}
