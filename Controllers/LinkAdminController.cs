using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppProject3.Data;

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

        // GET: LinkAdminController
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
        }
    }
}
