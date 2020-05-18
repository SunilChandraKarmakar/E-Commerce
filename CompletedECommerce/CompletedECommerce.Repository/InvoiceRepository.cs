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
    public class InvoiceRepository : BaseRepository<Invoice>, IInvoiceRepository
    {
        public override ICollection<Invoice> GetAll()
        {
            ICollection<Invoice> invoices = ecommerceDb.Invoices
                                            .Include(i => i.Account)
                                            .Include(i => i.InvoiceDetails).ToList();
            return invoices;
        }
    }
}
