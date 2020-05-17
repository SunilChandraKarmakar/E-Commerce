using CompletedECommerce.Manager.Base;
using CompletedECommerce.Manager.Contracts;
using CompletedECommerce.Repository.Contracts;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompletedECommerce.Manager
{
    public class InvoiceManager : BaseManager<Invoice>, IInvoiceManager
    {
        private readonly IInvoiceRepository _iInvoiceRepository;

        public InvoiceManager(IInvoiceRepository iInvoiceRepository) : base(iInvoiceRepository)
        {
            _iInvoiceRepository = iInvoiceRepository;
        }
    }
}
