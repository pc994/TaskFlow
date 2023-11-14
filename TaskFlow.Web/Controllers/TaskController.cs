using Microsoft.AspNetCore.Mvc;

namespace TaskFlow.Web.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
