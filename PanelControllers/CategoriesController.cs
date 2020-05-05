using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using BookDownloader.Models;
using BookDownloader.Repositry;
using Microsoft.AspNetCore.Mvc;

namespace BookDownloader.PanelControllers
{
    public class CategoriesController : Controller
    {
        public ICategoriesRepositry CategoriesRepositry { get; }
        public CategoriesController(ICategoriesRepositry categoriesRepositry)
        {
            CategoriesRepositry = categoriesRepositry;
        }

        public IActionResult Index()
        {

            return View(CategoriesRepositry.GetAll());
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                CategoriesRepositry.Add(category);
                CategoriesRepositry.SaveAll();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? ID)
        {
            if(ID == null)
            {
                return BadRequest("The request of Category is wrong");
            }
            Category category = CategoriesRepositry.GetByID(ID.Value);
            if(category == null)
            {
                return NotFound("The Category Not Found");
            }

            return View(category);

        }
        
        public IActionResult Details(int? ID)
        {
            if(ID == null)
            {
                return BadRequest("The request of Category is wrong");
            }
            Category category = CategoriesRepositry.GetByID(ID.Value);
            if (category == null)
            {
                return NotFound("The Category Not Found");
            }
            return View(category);

        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                CategoriesRepositry.Edit(category);
                CategoriesRepositry.SaveAll();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int? ID)
        {
            if (ID == null)
            {
                return BadRequest("The request of Category is wrong");
            }
            Category category = CategoriesRepositry.GetByID(ID.Value);
            if (category == null)
            {
                return NotFound("The Category Not Found");
            }
            return View(category);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int? ID)
        {
            if(ID == null)
            {
                return BadRequest("The request of Category is wrong");
            }
            Category category = CategoriesRepositry.GetByID(ID.Value);
            if(category == null)
            {
                return NotFound("The Category Not Found");
            }

            CategoriesRepositry.Delete(category);
            CategoriesRepositry.SaveAll();
            return RedirectToAction("Index");
           

        }

    }
}