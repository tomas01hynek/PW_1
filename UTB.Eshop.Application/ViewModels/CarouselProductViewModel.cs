﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.Eshop.Domain.Entities;

namespace UTB.Eshop.Application.ViewModels
{
    public class CarouselProductViewModel
    {
        public IList<Product> Products { get; set; }
        public IList<Carousel> Carousels { get; set; }
    }
}
