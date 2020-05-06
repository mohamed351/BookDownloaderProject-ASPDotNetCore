using System.Collections.Generic;

namespace BookDownloader.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Book>  Books { get; set; }
    }
}