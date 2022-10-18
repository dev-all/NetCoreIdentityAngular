using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace allshop.repository.Contracts
{
    public interface IRepository<T> where T : class
    {
        Task<T> Get(Guid id);
        Task<IEnumerable<T>> GetAll();
      //  Task<T> AddSave(T element); // remplazado por AddGetAsync
        void Add(T element);       
        void Update(T entity);
        Task<T> UpdateSave(T element);

        Task<bool> DeleteAsync(Guid id);

        Task<bool> Exist(Guid id);

        Task<bool> Save();

        Task<T> AddGetAsync(T element);

    }
}
