﻿using Microsoft.AspNetCore.Http;
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
            // initialize the model
            var link = new LinkModel();

            // get category from database using categoryId
            var category = _context.Categories.Find(categoryId);

            // set the category of the link
            link.LinkCategory = category;

            return View(link);
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

            // add the category to the link
            link.LinkCategory = _context.Categories.Find(categoryId);
            if (link.LinkCategory == null)
            {
                // add error message to ModelState
                ModelState.AddModelError("LinkCategory", "Invalid category");
                return View("Create");
            }

            // add the link to the database
            _context.Links.Add(link);
            _context.SaveChanges();

            // redirect to home page
            return RedirectToAction("Index", "Home");
        }
    }
}
