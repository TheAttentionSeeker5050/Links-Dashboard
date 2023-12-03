using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppProject3.Controllers
{
    public class CategoryController : Controller
    {
        // GET: CategoryController
        [HttpGet]
        [Route("/category/{id}")]
        public ActionResult Index()
        {
            return View();
        }

    }
}
