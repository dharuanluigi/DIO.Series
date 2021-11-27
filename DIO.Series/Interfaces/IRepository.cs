using System;
using System.Collections.Generic;
using System.Text;

namespace DIO.Series.Interfaces
{
    public interface IRepository<T>
    {
        List<T> Liist();

        T ReturnById(int id);

        void Insert(T entity);

        void Delete(int id);

        void Update(int id, T entity);

        int NextId();
    }
}
