using allshop.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allshop.repository.Contracts
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<Role> GetAsync(Guid id);
      
    }
}
