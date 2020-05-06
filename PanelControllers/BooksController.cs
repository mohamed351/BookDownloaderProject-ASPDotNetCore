using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookDownloader.Repositry;
using BookDownloader.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace BookDownloader.PanelControllers
{
    public class BooksController : Controller
    {
        private readonly IBookRepositry bookRepositry;
        private readonly ICategoriesRepositry categories;

        public BooksController(IBookRepositry bookRepositry
            , ICategoriesRepositry categories)
        {
            this.bookRepositry = bookRepositry;
            this.categories = categories;
        }
        public IActionResult Index(int pageNumber =0 , string searchElement="")
        {
            BookViewModelSelect select = new BookViewModelSelect()
            {
                Books = bookRepositry.GetBooksByPage(pageNumber, a => a.BookName.Contains(searchElement)),
                PagerView = new PagerViewModel(pageNumber
                ,searchElement
                , bookRepositry.GetPageCount(a=>a.BookName.Contains(searchElement)))
               
            };
            
            return View(select);
        }
        public IActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(this.categories.GetAll(), "ID", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(BookViewModelCreate viewModelCreate)
        {

            


            return View();
        }
    }
}