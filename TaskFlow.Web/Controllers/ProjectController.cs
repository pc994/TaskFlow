using Microsoft.AspNetCore.Mvc;

namespace TaskFlow.Web.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Edit(int projectId)
        {
            return View();
        }
    }
}
