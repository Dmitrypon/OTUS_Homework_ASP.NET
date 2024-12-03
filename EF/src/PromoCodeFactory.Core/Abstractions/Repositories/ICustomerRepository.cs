using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;


namespace PromoCodeFactory.Core.Abstractions.Repositories
{
    public interface ICustomerRepository : IRepository<Customer, Guid>
    {
    }
}
