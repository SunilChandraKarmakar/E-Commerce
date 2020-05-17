using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Invoice
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Provied name.")]
        [StringLength(2, MinimumLength = 20)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Select date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public bool Status { get; set; }

        [Required(ErrorMessage = "Select Account Name")]
        public int AccountId { get; set; }

        public Account Account { get; set; }
        public ICollection<InvoiceDetails> InvoiceDetails { get; set; }
    }
}
