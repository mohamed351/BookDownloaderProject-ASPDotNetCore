using BookDownloader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookDownloader.Repositry
{
    public class Repositry<T, ID> : IRepositry<T, ID> where T : class
    {
        private readonly BookDownloaderContext context;

        public Repositry(BookDownloaderContext context)
        {
            this.context = context;
        }
        public void Add(T Entity)
        {
            context.Set<T>().Add(Entity);

        }
        public void Edit(T Entity)
        {
            context.Update<T>(Entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

        }
        public void Delete(T Entity)
        {
            context.Update<T>(Entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }

        public IEnumerable<T> GetAll()
        {
           return  context.Set<T>().ToList();
        }

        public T GetByID(ID ID)
        {
            return context.Set<T>().Find(ID);
        }

        public int SaveAll()
        {
            return context.SaveChanges();
        }
    }
}
