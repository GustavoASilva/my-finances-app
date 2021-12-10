﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinances.SharedKernel
{
    public abstract class BaseEntity<TId>
    {
        public TId Id { get; set; }
    }
}
