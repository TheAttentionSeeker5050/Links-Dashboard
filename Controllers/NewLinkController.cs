using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppProject3.Data;
using WebAppProject3.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace WebAppProject3.Controllers
{
    public class NewLinkController : Controller
    {

        // will use Entity Framework to access database
        private ApplicationDbContext _context;

        // constructor for UserController
        private readonly ILogger<NewLinkController> _logger;

        public NewLinkController(ILogger<NewLinkController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: LinkController
        [HttpGet]
        [Route("/category/{categoryId}/link/create")]
        [Authorize]
        public IActionResult Create(int categoryId)
        {
            return View();
        }

        // POST: LinkController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/category/{categoryId}/link/create")]
        [Authorize]
        public IActionResult CreateSubmit(LinkModel link, int categoryId)
        {
            // validate the form
            if (!ModelState.IsValid)
            {
                return View("Create");
            }

            // add the link to the database
            _context.Links.Add(link);
            _context.SaveChanges();

            // redirect to home page
            return RedirectToAction("Index", "Home");
        }
/*
        // GET: LinkController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LinkController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LinkController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LinkController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LinkController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LinkController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LinkController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/
    }
}
