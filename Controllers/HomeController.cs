using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppProject3.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using WebAppProject3.Data;
/*using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text;
using System.IO;
using System.Net;
*/


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
            

            ViewBag.Links = links;

            return View();
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
