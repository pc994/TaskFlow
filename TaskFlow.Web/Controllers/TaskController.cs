using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskFlow.Application.Interfaces;
using TaskFlow.Application.Services;
using TaskFlow.Application.ViewModels.Comment;
using TaskFlow.Application.ViewModels.Task;
using TaskFlow.Domain.Model;
using static TaskFlow.Application.ViewModels.Comment.AddCommentVm;

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
        [HttpGet]
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
            var taskId = _taskService.AddTask(taskModel);
            return RedirectToAction("ViewTaskDetails", new { taskId = taskId });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddComment(AddCommentVm addComment)
        {
            //AddCommentValidation validator = new AddCommentValidation();
            //var validationResult = validator.Validate(addComment);
            //if (!validationResult.IsValid)
            //{
            //    // Obsługa błędów walidacji, np. dodanie błędów do ModelState.
            //    foreach (var error in validationResult.Errors)
            //    {
            //        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            //    }

            //    // Przekierowanie z powrotem do widoku z błędami.
            //    return View(ViewTaskDetails(1));


            //}

            var taskId = _taskService.AddComment(addComment);
            return RedirectToAction("ViewTaskDetails",new {taskId = taskId});
        }
        public IActionResult Remove(int taskId)
        {
            _taskService.RemoveTask(taskId);
            return RedirectToAction("Index");
        }
        //[HttpGet]
        //public IActionResult EditTask(int taskId) 
        //{
        //    var taskToEdit = _taskService.GetTaskForEdit(taskId);
        //    return View(taskToEdit); 
        //}
        [HttpGet]
        public IActionResult EditTask(int taskId)
        {
            var model = _taskService.EditTaskView(taskId);
              
            return View(model);
        }
        [HttpPost]
        public IActionResult EditTask(AddTaskVm taskModel)
        {
            var taskId = _taskService.UpdateTask(taskModel);

            return RedirectToAction("ViewTaskDetails", new { taskId = taskId });
        }
        [HttpPost]
        public IActionResult UpdateStatus(int taskId, int statusId)
        {
            _taskService.UpdateStatus(taskId, statusId);
            return RedirectToAction("ViewTaskDetails", new { taskId = taskId });
        }
    }
}
