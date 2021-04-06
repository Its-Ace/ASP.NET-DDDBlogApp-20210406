using BlogBasic.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogBasic.InfrastrutureCore.Repo
{
    public interface IRepository<T>
        where T:Entity
    {
        void Add(T entity);
        void Remove(T entity);
        void Update(int id, T entity);

        Task<ICollection<T>> GetAll();

        Task<T> Get(int id);

        Task<int> Max();
    }

}
