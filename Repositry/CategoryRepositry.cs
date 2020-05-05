using BookDownloader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookDownloader.Repositry
{
    public class CategoryRepositry : Repositry<Category, int>, ICategoriesRepositry
    {

        public CategoryRepositry(BookDownloaderContext context)
            :base(context)
        {

        }
    }
}
