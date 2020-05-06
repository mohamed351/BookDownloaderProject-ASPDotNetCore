using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookDownloader.ViewModels
{
    public class BookViewModelCreate
    {
        [Required]
        public string BookName { get; set; }
        [Required]
        public int CategoryID { get; set; }
        [Required]
        public IFormFile ImageBook{ get; set; }
        [Required]
        public IFormFile Book { get; set; }

        public ImageDetailsViewModel ImageDetails { get; set; }

    }
}
