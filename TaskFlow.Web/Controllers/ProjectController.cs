using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.Interfaces;

namespace TaskFlow.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
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
