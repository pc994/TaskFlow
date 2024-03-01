﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Domain.Model
{
    public class FilterCategory
    {
        public int FilterId { get; set; }
        public Filter Filter { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
