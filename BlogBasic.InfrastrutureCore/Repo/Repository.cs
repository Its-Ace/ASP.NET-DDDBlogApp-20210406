using BlogBasic.Core.Models;
using BlogBasic.InfrastrutureCore.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogBasic.InfrastrutureCore.Repo
{
    public class Repository<T> : IRepository<T>
        where T : Entity 
    {

        private DbContext context;

        protected DbSet<T> objectSet;
 
 
        public Repository(BlogContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            this.context = context;
            this.objectSet = context.Set<T>();
        }
        public virtual void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            objectSet.Add(entity);
            context.SaveChanges();
        }

        public virtual void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            objectSet.Remove(entity);
            context.SaveChanges();
        }
        public void Update(int id, T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            var existing = Get(id).Result;
            if (existing != null)
            {
                context.Entry(existing).CurrentValues.SetValues(entity);
            }
            context.SaveChanges();
        }

        public async Task<T> Get(int id)
        {
            return await objectSet.SingleAsync(t => t.Id == id);
        }

        public async Task<ICollection<T>> GetAll()
        {
            return await objectSet.ToListAsync();
        }
        public async Task<int> Max()
        {
            return await objectSet.MaxAsync(t => t.Id) + 1;
        }
    }
}
