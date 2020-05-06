using BookDownloader.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookDownloader.Repositry
{
    public class BookRepositry : Repositry<Book, int>, IBookRepositry
    {
        private readonly BookDownloaderContext context;

        public BookRepositry(BookDownloaderContext context) : 
            base(context)
        {
            this.context = context;
        }

        public IEnumerable<Book> GetBooksByPage(int pageNumber, Func<Book, bool> func)
        {
            return context.books.Where(func).Skip(10 * pageNumber)
                 .Take(10)
                 .OrderBy(a => a.ID)
                 .ToList();
        }

        public int GetPageCount(Func<Book,bool> func)
        {
            return (context.books.Where(func).Count())/10;
        }

       
    }
}
