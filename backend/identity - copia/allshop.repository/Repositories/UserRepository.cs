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
    public class UserRepository : IUserRepository
    {

        private readonly DatabaseContext _context;
        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public void Add(User element)
        {
            throw new NotImplementedException();
        }
        public async Task<User> AddGetAsync(User user)
        {           
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return await Task.FromResult(user); //Get(user.Id);
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool DeletePorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exist(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool ExistPorEmail(string email)
        {
            throw new NotImplementedException();
        }

        public bool ExistsPorID(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User> Get(Guid id)
        {
            var dbuser = _context.Users
                     .Include(x => x.Role)
                     .FirstOrDefaultAsync(x => x.Id == id);
            return dbuser;
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetPorNombre(string nombre)
        {
            throw new NotImplementedException();
        }



        public Task<User> SignIn(string email)
        {
            var dbuser = _context.Users
                    .Include(x => x.Role)
                    .FirstOrDefaultAsync(x => x.Email == email);
            return dbuser;
        }
        public Task<User> ExistEmail(string email)
        {
            var dbuser =  _context.Users
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.Email == email);
            return dbuser;
        }

        public User Login(string email, string Password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save()
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateSave(User element)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateAsync(User user)
        {
             _context.Users.Update(user);
             _context.SaveChangesAsync();                      
           return Get(user.Id);
        }
    }
}
