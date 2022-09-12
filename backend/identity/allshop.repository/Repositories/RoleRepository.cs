using allshop.domain.Entities;
using allshop.repository.Context;
using allshop.repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allshop.repository.Repositories
{
    public class RoleRepository : IRoleRepository
    {

        private readonly DatabaseContext _context;
        public RoleRepository(DatabaseContext context)
        {
            _context = context;

        }

        public void Add(Role element)
        {
            throw new NotImplementedException();
        }
        
        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exist(Guid id)
        {
            throw new NotImplementedException();
        }
        public Task<Role> Get(Guid id)
        {
            throw new NotImplementedException();
        }
        public async Task<Role> GetAsync(Guid id)
        {
           return await _context.Roles.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<IEnumerable<Role>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Role entity)
        {
            throw new NotImplementedException();
        }

        public Task<Role> UpdateSave(Role element)
        {
            throw new NotImplementedException();
        }

        public Task<Role> AddGetAsync(Role element)
        {
            throw new NotImplementedException();
        }
    }
}
