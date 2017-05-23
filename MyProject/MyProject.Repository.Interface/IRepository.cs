using System.Collections.Generic;
using MyProject.Domain.Model;
using System.Linq.Expressions;
using System;

namespace MyProject.Repository.Interface
{
    public interface IRepository<T> where T : Entity
    {
        void Save(T entity);

        void Delete(T entity);

        T Get(int id);

        IList<T> GetAll();
        PagedEntity<T> GetPaged(int page, int pagesize, Expression<Func<T, bool>> expression, string ordered);
        int Count();

    }
}