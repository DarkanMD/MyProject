using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Domain.Model;
using System.Collections;

namespace MyProject
{
    public interface IRepository<T> where T : Entity
    {
        void Save(T entity);

        void Delete(T entity);

        T Get(int id);

        IList<T> GetAll();

    }
}