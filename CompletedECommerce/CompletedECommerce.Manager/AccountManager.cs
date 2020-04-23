using CompletedECommerce.Manager.Base;
using CompletedECommerce.Manager.Contracts;
using CompletedECommerce.Repository.Contracts;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompletedECommerce.Manager
{
    public class AccountManager : BaseManager<Account>, IAccountManager
    {
        private readonly IAccountRepository _iAccountRepository;

        public AccountManager(IAccountRepository iAccountRepository) : base(iAccountRepository)
        {
            _iAccountRepository = iAccountRepository;
        }
    }
}
