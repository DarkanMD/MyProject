using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    public interface IRepository<T> where T : Entity
    {
        void Save(T entity);

        void Delete(T entity);

        T Get(long id);

    }
}