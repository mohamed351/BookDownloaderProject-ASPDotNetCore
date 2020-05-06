using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookDownloader.ViewModels
{
    public class PagerViewModel
    {
        public PagerViewModel(int pageNumber, string search , int Totalpager)
        {
            this.PageNumber = pageNumber;
            this.Search = search;
            this.TotalPages = Totalpager;

        }
        public int PageNumber { get; set; }
        public string Search { get; set; }
        public int TotalPages { get; set; }
        public int StartPoint
        {
            get
            {
                if (PageNumber <= 5)
                {
                    return 0;
                }
                else
                {
                    return PageNumber - 5;
                }
            }
        }


        public bool Pervious { get { return PageNumber > 0; } }
        public bool Next { get { return PageNumber < TotalPages; } }
    }
}
