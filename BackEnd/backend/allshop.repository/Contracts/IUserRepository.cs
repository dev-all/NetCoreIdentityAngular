using allshop.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allshop.repository.Contracts
{
    public interface IUserRepository : IRepository<User>
    {
        User Login(string email, string Password);
        bool ExistPorEmail(string email);
        bool ExistsPorID(Guid id);
        bool DeletePorId(Guid id);
        Task<IEnumerable<User>> GetPorNombre(string nombre);
        Task<User> SignIn(string email);
        Task<User> ExistEmail(string email);
        Task AddAsync(User user);
        Task<User> UpdateAsync(User user);
    }
}
