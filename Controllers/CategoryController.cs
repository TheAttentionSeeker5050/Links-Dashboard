using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppProject3.Data;
using WebAppProject3.Models;

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
        [Route("/category/{id}")]
        public ActionResult Edit()
        {
            // initiate the category model
            var category = new CategoryModel();

            return View(category);
        }

    }
}
