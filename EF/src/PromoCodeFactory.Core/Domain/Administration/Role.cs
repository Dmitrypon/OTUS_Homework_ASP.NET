﻿using PromoCodeFactory.Core.Domain;
using System;
using System.Collections;

namespace PromoCodeFactory.Core.Domain.Administration
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual IEnumerable<Employee> Employees { get; set; }
    }
}