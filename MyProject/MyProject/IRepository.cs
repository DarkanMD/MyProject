using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    public interface IRepository<T> where T : class
    {
        void Save<T>(T entity);

        void Delete<T>(T entity);

        T Get<T>(long id);

    }
}