using CompletedECommerce.Manager.Base;
using CompletedECommerce.Manager.Contracts;
using CompletedECommerce.Repository.Contracts;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompletedECommerce.Manager
{
    public class ProductManager : BaseManager<Product>, IProductManager 
    {
        private readonly IProductRepository _iProductRepository;

        public ProductManager(IProductRepository iProductRepository) : base(iProductRepository)
        {
            _iProductRepository = iProductRepository;
        }

        public override ICollection<Product> GetAll()
        {
            return _iProductRepository.GetAll();
        }
    }
}
