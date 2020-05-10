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
    public class RoleAccountRepository : BaseRepository<RoleAccount>, IRoleAccountRepository  
    {
        public override ICollection<RoleAccount> GetAll()
        {
            ICollection<RoleAccount> roleAccounts = ecommerceDb.RoleAccounts
                                                    .Include(ra => ra.Account).ToList();
            return roleAccounts;
        }
    }
}
