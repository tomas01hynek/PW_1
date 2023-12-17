﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.Eshop.Domain.Entities;

namespace UTB.Eshop.Infrastructure.Database
{
    public class DatabaseFake
    {
        public static List<Product> Products { get; set; }
        public static List<Carousel> Carousels { get; set; }

        static DatabaseFake()
        {
            DatabaseInit databaseInit = new DatabaseInit();
            Products = databaseInit.GetProducts().ToList();
            Carousels = databaseInit.GetCarousels().ToList();
        }
    }
}
