using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.CHALLENGE.INFRA.REPOSITORY.Services
{
    public abstract class GenericRepositorio<TEntity> where TEntity : class
    {
        protected readonly N5NowEFContext context;
        protected readonly DbSet<TEntity> Entity;

        protected GenericRepositorio(N5NowEFContext context)
        {
            this.context = context;
            Entity = context.Set<TEntity>();
        }

        protected async Task<bool> SaveChangesAsync()
        {
            int rowsAffected = await context.SaveChangesAsync();

            return rowsAffected > 0;
        }
    }
}
