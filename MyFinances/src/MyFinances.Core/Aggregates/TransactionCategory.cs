﻿using MyFinances.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinances.Core.Aggregates
{
    public class TransactionCategory: BaseEntity<int>, IAggregateRoot
    {
        public string Name { get; set; }
    }
}