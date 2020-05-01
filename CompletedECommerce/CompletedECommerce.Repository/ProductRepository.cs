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
    public class ProductRepository : BaseRepository<Product>, IProductRepository 
    {
        public override ICollection<Product> GetAll()
        {
            ICollection<Product> products = ecommerceDb.Products
                                            .Include(p => p.Category)
                                            .Include(p => p.ProductPhotos).ToList();
            return products;
        }
    }
}
