﻿using Microsoft.EntityFrameworkCore;
using PromoCodeFactory.DataAccess.Repositories;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.Core.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;

namespace PromoCodeFactory.DataAccess.Repositories
{
    public class CustomerRepository : EFRepository<Customer, Guid>, ICustomerRepository
    {
        public CustomerRepository(DataContext context) : base(context) 
        {
        }

        public override async Task<Customer> GetByIdAsync(Guid id)
        {
            var result = await _context.Set<Customer>().Where(x => x.Id == id).Include(x => x.CustomerPreferences).ThenInclude(x => x.Preference).FirstAsync();
            return result;
        }
    }
}
