using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookDownloader.Models;
using BookDownloader.Repositry;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookDownloader.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesApiController : ControllerBase
    {
        private readonly ICategoriesRepositry categories;

        public CategoriesApiController(ICategoriesRepositry categories)
        {
            this.categories = categories;
        }

        [HttpGet]
        public IEnumerable<Category> GetCategories()
        {
            return this.categories.GetAll();
        }
        [HttpGet(template: "{id}")]
        public ActionResult<Category> GetCategory(int? ID)
        {
            if (ID == null)
            {
                return BadRequest("The Category Request is Not Exist");
            }

            Category category = this.categories.GetByID(ID.Value);
            if (category == null)
            {
                return NotFound("The Category is not Found");

            }


            return Ok(category);
        }
        [HttpPut(template:"{id}")]
        public IActionResult PutCategory(int?ID,[FromBody]Category category)
        {
            if(ID == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
              Category categoryOld =  categories.GetByID(ID.Value);
                if(categoryOld == null)
                {
                    return NotFound("The Category is not Exist ..");
                }
                categoryOld.Name = category.Name;
                categories.Edit(categoryOld);
                return NoContent();
                
            }
            return BadRequest("The Catgory data is not valid");
         
        }
        [HttpDelete(template:"{id}")]
        public IActionResult DeleteCateogry(int?ID)
        {
            if(ID == null)
            {
                return BadRequest("The ID is Missing");
            }
           Category category =  this.categories.GetByID(ID.Value);
            if(category == null)
            {
                return NotFound("The Name is not Exsit");
            }
            this.categories.Delete(category);
            return Ok(category);
        }
        [HttpGet]
        [Route("/BookCategories")]
        public IEnumerable<Category> GetCategoriesWithBooks()
        {
            return categories.GetCategoriesWithBooks();
        }
         [HttpGet]
        [Route("/BookCategory/{id}")]
        public ActionResult<Category> GetCategoryWithBooks(int? ID)
        {
            if(ID == null)
            {
                return NotFound("the category is not found");
            }
            return categories.GetCategoryWithBooks(ID.Value);
        }
        [HttpPost]
        public IActionResult PostCategory([FromBody]Category category)
        {
            if (ModelState.IsValid)
            {
                this.categories.Add(category);
                this.categories.SaveAll();
                return Ok(category);

            }
            return BadRequest("The Category information is not valid");
          
        }



    }
}