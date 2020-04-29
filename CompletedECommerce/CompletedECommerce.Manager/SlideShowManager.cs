using CompletedECommerce.Manager.Base;
using CompletedECommerce.Manager.Contracts;
using CompletedECommerce.Repository.Contracts;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompletedECommerce.Manager
{
    public class SlideShowManager : BaseManager<SlideShow>, ISlideShowManager 
    {
        private readonly ISlideShowRepository _iSlideShowRepository;

        public SlideShowManager(ISlideShowRepository iSlideShowRepository) : base(iSlideShowRepository)
        {
            _iSlideShowRepository = iSlideShowRepository;
        }
    }
}
