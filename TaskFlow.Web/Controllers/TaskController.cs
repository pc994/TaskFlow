using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.Services;

namespace TaskFlow.Web.Controllers
{
    public class TaskController : Controller
    {
        private readonly TaskService _taskService;
        public IActionResult Index()
        {
            var model = _taskService.GetAllTasksForList(); 
            return View(model);
        }

        public IActionResult ViewTaskDetails(int taskId)
        {
            var model = _taskService.GetTaskDetails(taskId);
            return View(model);
        }
    }
}
