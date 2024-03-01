using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskFlow.Application.Interfaces;
using TaskFlow.Application.Services;
using TaskFlow.Application.ViewModels.Comment;
using TaskFlow.Application.ViewModels.Filter;
using TaskFlow.Application.ViewModels.Task;
using TaskFlow.Domain.Model;
using static TaskFlow.Application.ViewModels.Comment.AddCommentVm;

namespace TaskFlow.Web.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly IValidator<AddTaskVm> _validator;

        public TaskController(ITaskService taskService, IValidator<AddTaskVm> validator)
        {
            _taskService = taskService;
            _validator = validator;
        }
        [HttpGet]
        public IActionResult Index()
        {
            TaskFiltersVm taskFiltersVm = new TaskFiltersVm();
            var model = _taskService.GetTasksForList(10, 1, "", taskFiltersVm);
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(int pageSize, int? pageNo, string searchString, TaskFiltersVm taskFiltersVm)
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }
            if (searchString is null)
            {
                searchString = String.Empty;
            }
            var model = _taskService.GetTasksForList(pageSize, pageNo.Value, searchString, taskFiltersVm);
            return View(model);
        }
        //[HttpPost]
        //public IActionResult ApplyFilter(TaskFiltersVm taskFiltersVm)
        //{
        //    var model = _taskService.ApplyFilter(taskFiltersVm);

        //    return RedirectToAction("Index");

        //}
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
        public IActionResult AddComment(AddCommentVm addComment)
        {
            var taskId = _taskService.AddComment(addComment);
            return RedirectToAction("ViewTaskDetails", new { taskId = taskId });
        }
        [HttpGet]
        public IActionResult ConfirmClose(int taskId)
        {
            var model = _taskService.GetTaskDetails(taskId);
            return View(model);
        }
        [HttpPost]
        public IActionResult Close(int taskId, int statusId)
        {
            _taskService.UpdateStatus(taskId, statusId);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditTask(int taskId)
        {
            var model = _taskService.UpdateTaskView(taskId);
            return View(model);
        }
        [HttpPost]
        public IActionResult EditTask(AddTaskVm taskModel)
        {
            _taskService.UpdateTask(taskModel);
            return RedirectToAction("ViewTaskDetails", new { taskId = taskModel.Id });
        }
        [HttpPost]
        public IActionResult UpdateStatus(int taskId, int statusId)
        {
            _taskService.UpdateStatus(taskId, statusId);
            return RedirectToAction("ViewTaskDetails", new { taskId = taskId });
        }
        [HttpGet]
        public IActionResult TaskPreview(int taskId)
        {
            var model = _taskService.GetTaskDetails(taskId);
            return View(model);
        }

        public IActionResult CreateFilter(TaskFiltersVm taskFiltersVm)
        {
            _taskService.SaveFilters(taskFiltersVm);
            return RedirectToAction("Index");
        }
        
        //public IActionResult ApplyFilter(int filterId)
        //{
        //    var filtervm = _taskService.GetFilterDetailsByFilterId(filterId);
        //    return RedirectToAction("Index", new {pageSize = 10,pageNo= 1,searchString = "", taskFiltersVm = filtervm });
        //}
    }
}
