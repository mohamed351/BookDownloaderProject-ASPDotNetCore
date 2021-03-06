﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookDownloader.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string BookName { get; set; }
        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public  virtual Category Category { get; set; }
        public string ImageUrl { get; set; }
        public string  BookUrl { get; set; }

    }
}
