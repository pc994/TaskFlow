using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.Interfaces;
using TaskFlow.Application.ViewModels.Project;
using TaskFlow.Application.ViewModels.Task;
using TaskFlow.Domain.Interfaces;
using TaskFlow.Domain.Model;

namespace TaskFlow.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        public ProjectService(IProjectRepository projectRepository, IMapper mapper, ITaskRepository taskRepository)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
            _taskRepository = taskRepository;
        }

        public int AddProject(AddProjectVm addProjectVm)
        {
            var project = _mapper.Map<Project>(addProjectVm);
            project.IsActive = true;
            var projectId = _projectRepository.AddProject(project);
            return project.Id;
        }

        public ListProjectToListVm GetAllActiveProjects()
        {
            var projects = _projectRepository.GetAllActiveProjects().ProjectTo<ProjectForListVm>(_mapper.ConfigurationProvider).ToList();
            var listOfProjects = new ListProjectToListVm()
            {
                Projects = projects,
                Count = projects.Count
            };
            return listOfProjects;
        }

        public ListProjectToListVm GetAllInactiveProjects()
        {
            var projects = _projectRepository.GetAllInactiveProjects().ProjectTo<ProjectForListVm>(_mapper.ConfigurationProvider).ToList();
            var listOfProjects = new ListProjectToListVm()
            {
                Projects = projects,
                Count = projects.Count
            };
            return listOfProjects;
        }

        public ProjectDetailsVm GetProjectDetails(int projectId)
        {
            var project = _projectRepository.GetProjectById(projectId);
            var projectDetailsVm = _mapper.Map<ProjectDetailsVm>(project);
            projectDetailsVm.TasksCount = CountTasksByProjectId(projectId);
            return projectDetailsVm;
        }

        public AddProjectVm UpdateProjectView(int projectId)
        {
            var project = GetProjectDetails(projectId);
            AddProjectVm projectVm = new AddProjectVm();
            projectVm.Id = project.Id;
            projectVm.Name = project.Name;
            projectVm.IsActive = project.IsActive;
            projectVm.ProjectDetail = project.ProjectDetail;
            return projectVm;
        }

        public int UpdateProject(AddProjectVm addProjectVm)
        {
            var project = _mapper.Map<Project>(addProjectVm);
            var projectId = _projectRepository.UpdateProject(project);
            return projectId;
        }

        public void EndProject(int projectId)
        {
            _projectRepository.EndProject(projectId);
        }

        public bool CheckPossibilityEndProject(int projectId)
        {
            var tasks = GetTasksByProjectId(projectId);
            if (tasks.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public ListTaskForListVm GetActiveTasksByProjectId(int projectId)
        {
            var tasks = _taskRepository.GetActiveTasksByProjectId(projectId).ProjectTo<TaskForListVm>(_mapper.ConfigurationProvider).ToList();
            var listOfTasks = new ListTaskForListVm()
            {
                Tasks = tasks,
                Count = tasks.Count
            };
            return listOfTasks;
        }

        public int CountActiveTasksByProjectId(int projectId)
        {
            var count = _taskRepository.CountActiveTasksByProjectId(projectId);
            return count;
        }

        public int CountTasksByProjectId(int projectId)
        {
            var count = _taskRepository.CountTasksByProjectId(projectId);
            return count;
        }

        private List<TaskForListVm> GetTasksByProjectId(int projectId)
        {
            var tasks = _taskRepository.GetTaskByProjectId(projectId).ProjectTo<TaskForListVm>(_mapper.ConfigurationProvider).ToList();
            return tasks;
        }
    }
}
