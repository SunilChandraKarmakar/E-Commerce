using CompletedECommerce.Manager.Base;
using CompletedECommerce.Manager.Contracts;
using CompletedECommerce.Repository.Contracts;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompletedECommerce.Manager
{
    public class RoleAccountManager : BaseManager<RoleAccount>, IRoleAccountManager 
    {
        private readonly IRoleAccountRepository _iRoleAccountRepository;

        public RoleAccountManager(IRoleAccountRepository iRoleAccountRepository) : base(iRoleAccountRepository)
        {
            _iRoleAccountRepository = iRoleAccountRepository;
        }

        public override ICollection<RoleAccount> GetAll()
        {
            return _iRoleAccountRepository.GetAll();
        }
    }
}
