using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Diagnostics;
using TaskFlow.Application.Interfaces;
using TaskFlow.Application.ViewModels.Project;
using TaskFlow.Application.ViewModels.Task;

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
            var model = _projectService.GetAllActiveProjects();
            return View(model);
        }
        [HttpGet]
        public IActionResult AddProject()
        {
            var model = _projectService.AddProjectView();
            return View(model);
        }
        [HttpPost]
        public IActionResult AddProject(AddProjectVm addProjectVm)
        {
            var projectId = _projectService.AddProject(addProjectVm);
            return RedirectToAction("Index");
        }
        public IActionResult ProjectToEnd(int projectId)
        {
            var listOfTasks = _projectService.CountActiveTasksByProjectId(projectId);

            if (listOfTasks > 0)
            {
                return RedirectToAction("ListOfTasksByProjectId", new { projectId });
            }
            else
            {
                return RedirectToAction("ConfirmEndProjectView", new { projectId });
            }
        }
        [HttpGet]
        public IActionResult ListOfTasksByProjectId(int projectId)
        {
            ViewBag.ProjectId = projectId;
            var model = _projectService.GetActiveTasksByProjectId(projectId);
            return View(model);
        }
        [HttpGet]
        public IActionResult ConfirmEndProjectView(int projectId)
        {
            var model = _projectService.GetProjectDetails(projectId);
            return View(model);
        }
        [HttpPost]
        public IActionResult EndProject(int projectId)
        {
            _projectService.EndProject(projectId);
            return RedirectToAction("ViewInactiveProjects");
        }
        [HttpGet]
        public IActionResult ViewProjectDetails(int projectId)
        {
            var model = _projectService.GetProjectDetails(projectId);
            return View(model);
        }
        [HttpGet]
        public IActionResult UpdateProject(int projectId)
        {
            var model = _projectService.UpdateProjectView(projectId);
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateProject(AddProjectVm projectModel)
        {
            _projectService.UpdateProject(projectModel);
            return RedirectToAction("ViewProjectDetails", new { projectId = projectModel.Id });
        }
        [HttpGet]
        public IActionResult ViewInactiveProjects()
        {
            var model = _projectService.GetAllInactiveProjects();
            return View(model);
        }
    }
}
