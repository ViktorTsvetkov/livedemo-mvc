using System;
using System.Linq;

namespace LiveDemo_MVC.Data.Contracts
{
    public interface IEfDbSetWrapper<T>
        where T : class
    {
        IQueryable<T> All { get; }

        T GetById(Guid id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}