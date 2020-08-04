using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleNosqlGuestbook
{
    public interface IGenericRepository<T> where T: class
    {
        public void Add(T item);
        public List<T> GetAll();
    }
}
