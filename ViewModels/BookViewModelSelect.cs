using BookDownloader.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookDownloader.ViewModels
{
    public class BookViewModelSelect
    {
      

        public IEnumerable<Book>  Books { get; set; }
        public PagerViewModel PagerView { get; set; }

    }
}
