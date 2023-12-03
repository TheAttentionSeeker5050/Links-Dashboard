using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppProject3.Data;
using WebAppProject3.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace WebAppProject3.Controllers
{
    public class CategoryController : Controller
    {
        // will use Entity Framework to access database
        private ApplicationDbContext _context;

        private readonly ILogger<HomeController> _logger;

        public CategoryController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: CategoryController
        [HttpGet]
        [Authorize]
        [Route("/category/{id}")]
        public IActionResult Edit()
        {
            // get the category id from the route
            var id = RouteData.Values["id"].ToString();
            var category = _context.Categories.FirstOrDefault(
                                   c => c.CategoryId.ToString() == id);

            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        [Route("/category/{id}")]
        public async Task<IActionResult> EditSubmit(CategoryModel category, int id)
        {
            // validate the form
            if (!ModelState.IsValid)
            {
                return View("Edit");
            }

            try
            {
                // find the Category model by id
                var categoryFromDb = _context.Categories.FirstOrDefault(
                                                      c => c.CategoryId == id);
                if (categoryFromDb == null)
                {
                    // return error on form
                    ModelState.AddModelError("Category", "Category not found");
                    return View("Edit");
                }

                // update the category name
                categoryFromDb.CategoryName = category.CategoryName;

                // save changes to database
                _context.Categories.Update(categoryFromDb);
                _context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                
                return View("Edit");
            }
        }

    }
}
