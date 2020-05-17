using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public int AccountId { get; set; }

        public Account Account { get; set; }
        public ICollection<InvoiceDetails> InvoiceDetails { get; set; }
    }
}
