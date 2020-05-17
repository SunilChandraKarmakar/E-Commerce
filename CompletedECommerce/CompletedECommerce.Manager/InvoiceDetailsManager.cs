using CompletedECommerce.Manager.Base;
using CompletedECommerce.Manager.Contracts;
using CompletedECommerce.Repository.Base;
using CompletedECommerce.Repository.Contracts;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompletedECommerce.Manager
{
    public class InvoiceDetailsManager : BaseManager<InvoiceDetails>, IInvoiceDetailsManager
    {
        private readonly IInvoiceDetailsRepository _iInvoiceDetailsRepository;

        public InvoiceDetailsManager(IInvoiceDetailsRepository iInvoiceDetailsRepository) : base(iInvoiceDetailsRepository)
        {
            _iInvoiceDetailsRepository = iInvoiceDetailsRepository;
        }
    }
}
