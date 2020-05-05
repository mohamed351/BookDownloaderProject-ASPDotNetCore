using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookDownloader.Repositry
{
   public interface IRepositry<T, ID> where T:class
    {

       public  IEnumerable<T> GetAll();
        public T GetByID(ID ID);
        public void Add(T Entity);
        public void Edit(T Entity);
        public void Delete(T Entity);
        public int SaveAll();
       

    }
}
