using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookDownloader.Models;
using BookDownloader.Repositry;
using BookDownloader.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.Extensions.Localization.Internal;


namespace BookDownloader.PanelControllers
{
    public class BooksController : Controller
    {
        private readonly IBookRepositry bookRepositry;
        private readonly ICategoriesRepositry categories;
        private readonly IWebHostEnvironment hostEnvironment;

        public BooksController(IBookRepositry bookRepositry
            , ICategoriesRepositry categories,
            IWebHostEnvironment hostEnvironment)
        {
            this.bookRepositry = bookRepositry;
            this.categories = categories;
            this.hostEnvironment = hostEnvironment;
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
        public async Task<IActionResult> Create(BookViewModelCreate viewModelCreate)
        {
            if (ModelState.IsValid)
            {
                string ImageName = ImportImage(viewModelCreate.ImageDetails, viewModelCreate.ImageBook);
                string Book =  ImportBook(viewModelCreate.Book);
                Book book = new Book()
                {
                    BookName = viewModelCreate.BookName,
                    BookUrl = Book,
                    ImageUrl = ImageName,
                    CategoryID = viewModelCreate.CategoryID

                };

                bookRepositry.Add(book);
                bookRepositry.SaveAll();

            }
            
            ViewBag.CategoryID = new SelectList(this.categories.GetAll(), "ID", "Name");
            return View();
        }


        #region Helpers
        public string ImportImage(ImageDetailsViewModel viewModel, IFormFile ImageForm)
        {

            Rectangle rectangle = new Rectangle(
               Convert.ToInt32(viewModel.X),
                Convert.ToInt32(viewModel.Y),
               Convert.ToInt32(viewModel.Width),
                Convert.ToInt32(viewModel.Height));

            Bitmap bitmapSrc = Image.FromStream(ImageForm.OpenReadStream()) as Bitmap;
            Bitmap Bitmaptarget = new Bitmap(Convert.ToInt32(viewModel.Width), Convert.ToInt32(viewModel.Height));
            using (Graphics g = Graphics.FromImage(Bitmaptarget))
            {
                g.DrawImage(bitmapSrc, new Rectangle(0, 0, Convert.ToInt32(viewModel.Width), Convert.ToInt32(viewModel.Height)),
                                 rectangle,
                                 GraphicsUnit.Pixel);
                string NewFileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageForm.FileName);
                Bitmaptarget.Save(Path.Combine(this.hostEnvironment.WebRootPath, "images", NewFileName));
                return NewFileName;

            }

        }

        public  string ImportBook(IFormFile bookFile)
        {
            Stream file = bookFile.OpenReadStream();
            string NewFileName = Path.Combine(hostEnvironment.WebRootPath, "books", Guid.NewGuid() + Path.GetExtension(bookFile.FileName));
            FileStream fileStream = new FileStream(NewFileName, FileMode.Create);
            bookFile.OpenReadStream().CopyTo(fileStream);
           
            return NewFileName;
        }
        #endregion
    }
}