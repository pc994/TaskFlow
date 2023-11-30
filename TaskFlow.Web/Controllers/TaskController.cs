using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.Interfaces;
using TaskFlow.Application.Services;
using TaskFlow.Application.ViewModels.Task;
using TaskFlow.Domain.Model;

namespace TaskFlow.Web.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
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
            var model = _taskService.AddTaskView();
            return View(model);
        }
        [HttpPost]
        public IActionResult AddTask(AddTaskVm taskModel)
        {
            var id = _taskService.AddTask(taskModel);
            return RedirectToAction("Index");
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
