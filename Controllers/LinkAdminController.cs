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

                // update the fields
                linkFromDb.LinkLabel = link.LinkLabel;
                linkFromDb.LinkHref = link.LinkHref;
                linkFromDb.IsPinned = link.IsPinned;
                linkFromDb.FaviconSrc = link.FaviconSrc;


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

        /*// GET: LinkAdminController
        public ActionResult Index()
        {
            return View();
        }

        // GET: LinkAdminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LinkAdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LinkAdminController/Create
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

        // GET: LinkAdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LinkAdminController/Edit/5
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

        // GET: LinkAdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LinkAdminController/Delete/5
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
