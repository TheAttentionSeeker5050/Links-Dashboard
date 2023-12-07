using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppProject3.Data;
using Microsoft.AspNetCore.Authorization;
using WebAppProject3.Models;


namespace WebAppProject3.Controllers
{
    public class LinkAdminController : Controller
    {
        // will use Entity Framework to access database
        private ApplicationDbContext _context;

        // constructor for UserController
        private readonly ILogger<LinkAdminController> _logger;

        public LinkAdminController(ILogger<LinkAdminController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // edit link get request
        [HttpGet]
        [Route("/category/{categoryId}/link/{linkId}/edit")]
        [Authorize]
        public IActionResult Edit(int linkId, int categoryId)
        {
            // get link from database using linkId, and include the category
            var link = _context.Links.First(l => l.LinkId == linkId);

            // get category from database using categoryId and set ViewBag
            var category = _context.Categories.Find(categoryId);
            link.LinkCategory = category;

            // add a viewbag for all the category list
            ViewBag.Categories = _context.Categories.ToArray();

            // return view with link
            return View(link);
        }

        // edit link post request
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/category/{categoryId}/link/{linkId}/edit")]
        [Authorize]
        public IActionResult EditSubmit(LinkModel link, int linkId, int categoryId)
        {
            // validate the form
            if (!ModelState.IsValid)
            {
                return View("Edit");
            }

            try
            {
                   // find the Link model by id
                var linkFromDb = _context.Links.Find(linkId);
                if (linkFromDb == null)
                {
                    // return error on form
                    ModelState.AddModelError("Link", "Link not found");
                    return View("Edit");
                }

                Console.WriteLine("Category on post form: "+ link.LinkCategory.CategoryId);

                // update the fields
                linkFromDb.LinkLabel = link.LinkLabel;
                linkFromDb.LinkCategoryCategoryId = link.LinkCategoryCategoryId; // Setting the foreign key
                linkFromDb.LinkHref = link.LinkHref;
                linkFromDb.IsPinned = link.IsPinned;
                linkFromDb.FaviconSrc = link.FaviconSrc;

                // Console.WriteLine("Category: "+ linkFromDb.LinkCategory?.CategoryId + " " + linkFromDb.LinkCategory?.CategoryName);


                // update the link
                _context.Links.Update(linkFromDb);
                _context.SaveChanges();

                // redirect to the category page
                return Redirect($"/");
            }
            catch
            {
                // return error on form
                ModelState.AddModelError("Link", "Could not update link");
                return View("Edit");
            }
        }

        // delete link get request
        [HttpGet]
        [Route("/category/{categoryId}/link/{linkId}/delete")]
        [Authorize]
        public IActionResult Delete(int linkId, int categoryId)
        {
            // get link from database using linkId, and include the category
            var link = _context.Links.First(l => l.LinkId == linkId);

            // no need to get category from database, we won't use it anyway

            // return view with link
            return View(link);
        }

        // delete link post request
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/category/{categoryId}/link/{linkId}/delete")]
        [Authorize]
        public IActionResult DeleteSubmit(int linkId)
        {
            try
            {
                // find the Link model by id
                var linkFromDb = _context.Links.Find(linkId);
                if (linkFromDb == null)
                {
                    // return error on form
                    ModelState.AddModelError("Link", "Link not found");
                    return View("Delete");
                }

                // delete the link
                _context.Links.Remove(linkFromDb);
                _context.SaveChanges();

                // redirect to the category page
                return Redirect($"/");
            }
            catch
            {
                // return error on form
                ModelState.AddModelError("Link", "Could not delete link");
                return View("Delete");
            }
        }

    }
}
