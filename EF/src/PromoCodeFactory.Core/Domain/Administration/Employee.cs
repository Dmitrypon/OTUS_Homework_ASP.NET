﻿using System;
using System.Collections;
using PromoCodeFactory.Core.Domain;
using System.Collections.Generic;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;

namespace PromoCodeFactory.Core.Domain.Administration
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Email { get; set; }
        public Guid RoleId { get; set }
        public virtual Role Role { get; set; }
        public int AppliedPromocodesCount { get; set; }
        public virtual IEnumerable<PromoCode> PromoCodes { get; set; }        
    }
}