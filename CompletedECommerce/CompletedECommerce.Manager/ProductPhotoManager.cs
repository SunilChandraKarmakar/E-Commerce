using CompletedECommerce.Manager.Base;
using CompletedECommerce.Manager.Contracts;
using CompletedECommerce.Repository.Contracts;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompletedECommerce.Manager
{
    public class ProductPhotoManager : BaseManager<ProductPhoto>, IProductPhotoManager 
    {
        private readonly IProductPhotoRepository _iProductPhotoRepository;

        public ProductPhotoManager(IProductPhotoRepository iProductPhotoRepository) : base(iProductPhotoRepository)
        {
            _iProductPhotoRepository = iProductPhotoRepository;
        }
    }
}
