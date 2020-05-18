using CompletedECommerce.Repository.Base;
using CompletedECommerce.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompletedECommerce.Repository
{
    public class InvoiceDetailsRepository : BaseRepository<InvoiceDetails>, IInvoiceDetailsRepository
    {
        public override ICollection<InvoiceDetails> GetAll()
        {
            ICollection<InvoiceDetails> invoiceDetails = ecommerceDb.InvoiceDetails
                                                         .Include(id => id.Invoice)
                                                         .Include(id => id.Product)
                                                         .ToList();
            return invoiceDetails;
        }
    }
}
