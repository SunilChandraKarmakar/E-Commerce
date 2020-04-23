using CompletedECommerce.Manager.Base;
using CompletedECommerce.Manager.Contracts;
using CompletedECommerce.Repository.Contracts;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompletedECommerce.Manager
{
    public class RoleManager : BaseManager<Role>, IRoleManager 
    {
        private readonly IRoleRepository _iRoleRepository;

        public RoleManager(IRoleRepository iRoleRepository) : base(iRoleRepository)
        {
            _iRoleRepository = iRoleRepository;
        }
    }
}
