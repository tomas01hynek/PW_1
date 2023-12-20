﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTB.Eshop.Domain.Entities
{
    public class Carousel : Entity<int>
    {
        [Required]
        public string? ImageSrc { get; set; }
        public string? ImageAlt { get; set; }
    }
}
