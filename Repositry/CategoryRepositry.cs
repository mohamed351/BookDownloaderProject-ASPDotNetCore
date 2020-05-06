using BookDownloader.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookDownloader.Repositry
{
    public class CategoryRepositry : Repositry<Category, int>, ICategoriesRepositry
    {
        private readonly BookDownloaderContext context;

        public CategoryRepositry(BookDownloaderContext context)
            :base(context)
        {
            this.context = context;
        }

        public IEnumerable<Category> GetCategoriesWithBooks()
        {
            return context.Categories.Include(a => a.Books)
                  .ToList();
        }

        public Category GetCategoryWithBooks(int ID)
        {
            return context.Categories
                .Include(a => a.Books)
                .FirstOrDefault(a => a.ID == ID);

        }
    }
}
