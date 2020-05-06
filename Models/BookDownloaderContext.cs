using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookDownloader.Models
{
    public class BookDownloaderContext:IdentityDbContext<ApplicationUsers>
    {

        public BookDownloaderContext(DbContextOptions contextOptions)
            :base(contextOptions)
        {
            
        }
        public DbSet<Book> books { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(); 
        }

    }
}
