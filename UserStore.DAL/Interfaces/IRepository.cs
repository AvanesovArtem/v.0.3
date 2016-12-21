using System;
using System.Collections.Generic;

namespace UserStore.DAL.Interfaces
{
   public interface IRepository<T> where T:class
    {
        IList<T> GetAll();
        T GetById(int id);
        T Find(Func<T, Boolean> predicate);
        void Create(T item);
        void Update(T item);
        void Delete(T item);
    }
}
