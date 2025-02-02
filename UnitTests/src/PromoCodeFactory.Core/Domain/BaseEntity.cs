﻿using System;
using PromoCodeFactory.Core.Domain.Base;

namespace PromoCodeFactory.Core.Domain
{
    public abstract class BaseEntity : TEntity<Guid>
    {
        public Guid Id { get; set; }
    }
}