﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinances.Core.Aggregates
{
    public class Category: BaseEntity<int>
    {
        public string Name { get; set; }
    }
}
