using BookDownloader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookDownloader.Repositry
{
   public  interface IBookRepositry: IRepositry<Book, int>
    {

        IEnumerable<Book> GetBooksByPage(int pageNumber, Func<Book, bool> func);
        int GetPageCount(Func<Book, bool> func);
    }
}
