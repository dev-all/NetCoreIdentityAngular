using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allshop.repository.Contracts
{
    internal interface IAppDBContext
    {
        // DbSet<UserEntity> Users { get; set; }
      //  DbSet<Persona> Personas { get; set; }

        //Operaciones habilitadas que hace el Contexto

        //DbSet<TEntity> Set<TEntity>() where TEntity : class;

        //DatabaseFacade Database { get; }

        //Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        //void RemoveRange(IEnumerable<object> entities);

        //EntityEntry Update(object entity);
    }
}
