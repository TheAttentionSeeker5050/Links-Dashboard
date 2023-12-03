using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppProject3.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using WebAppProject3.Data;
using System.Linq;
using System;



namespace WebAppProject3.Controllers
{
    public class HomeController : Controller
    {
        
        // will use Entity Framework to access database
        private ApplicationDbContext _context;

        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [Route("/")]
        [HttpGet]
        public IActionResult Index()
        {
            // using Entity Framework, get all links from database
            var links = _context.Links.ToArray();

            // add all the categories to ViewBag
            ViewBag.Categories = _context.Categories.ToArray();

            // add all distinct link labels to ViewBag
            ViewBag.LinkLabels = _context.Links.Select(l => l.LinkLabel).Distinct().ToArray();

            // order by category name and pinned first and link label
            links = _context.Links.OrderBy(l => l.LinkCategory.CategoryName).ThenBy(l => l.LinkLabel).ToArray();

            
            ViewBag.Links = links;
            
            return View(links);
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
