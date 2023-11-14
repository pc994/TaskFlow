using Microsoft.AspNetCore.Mvc;

namespace TaskFlow.Web.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
