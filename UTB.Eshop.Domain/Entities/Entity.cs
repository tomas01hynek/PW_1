﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTB.Eshop.Domain.Entities
{
    public abstract class Entity<T>
    {
        [Key]
        [Required]
        public T Id { get; set; }
    }
}
