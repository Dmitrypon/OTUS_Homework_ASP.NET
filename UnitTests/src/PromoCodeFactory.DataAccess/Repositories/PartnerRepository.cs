﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;

namespace PromoCodeFactory.DataAccess.Repositories
{
    internal class PartnerRepository : EFRepository<Partner, Guid>, IPartnerRepository
    {
        public PartnerRepository(DataContext context) : base(context)
        {
        }
        public override async Task<IEnumerable<Partner>> GetAllAsync()
        {
            IQueryable<Partner> query = _context.Set<Partner>().Include(x => x.PartnerLimits).AsNoTracking();
            return await query.ToListAsync();
        }
        public override async Task<Partner> GetByIdAsync(Guid id)
        {
            var result = await _context.Set<Partner>().Where(x => x.Id == id).Include(x => x.PartnerLimits).FirstAsync();
            return result;
        }
    }
}
