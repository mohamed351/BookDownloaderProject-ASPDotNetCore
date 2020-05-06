using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookDownloader.ViewModels
{
    public class BookViewModelEdit
    {
        public int ID { get; set; }
        [Required]
        public string BookName { get; set; }
        [Required]
        public int CategoryID { get; set; }
        public IFormFile ImageFile { get; set; }

        public IFormFile BookFile { get; set; }

    }
}
