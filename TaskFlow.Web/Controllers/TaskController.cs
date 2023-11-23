using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.Services;
using TaskFlow.Domain.Model;

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
        [HttpGet]
        public IActionResult AddTask()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTask(TaskModel taskModel)
        {
            var id = _taskService.AddTask(taskModel);
            return View();
        }

        public IActionResult Delete()
        {
            return View();  
        }
        public IActionResult Edit(int taskId) 
        {
            return View(); 
        }  
    }
}
