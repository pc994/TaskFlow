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
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;
        public TaskService(IMapper mapper, ITaskRepository taskRepository, IProjectRepository projectRepository)
        {
            _taskRepository = taskRepository;
            _projectRepository = projectRepository;
            _mapper = mapper;
        }
        public int AddTask(AddTaskVm addTaskVm)
        {
            var task = _mapper.Map<TaskFlow.Domain.Model.Task>(addTaskVm);
            var id = _taskRepository.AddTask(task);
            return id;
        }

        public AddTaskVm AddTaskView()
        {
            AddTaskVm addTaskVm = new AddTaskVm();
            var taskCategories = _taskRepository.GetAllTaskCategories().ProjectTo<TaskCategoriesForListVm>(_mapper.ConfigurationProvider).ToList();
            var taskPriorities = _taskRepository.GetAllTaskPriorities().ProjectTo<TaskPrioritiesForListVm>(_mapper.ConfigurationProvider).ToList();
            var projects = _projectRepository.GetAllActiveProjects().ProjectTo<ProjectForListVm>(_mapper.ConfigurationProvider).ToList();
            addTaskVm.Categories = taskCategories;
            addTaskVm.Priorities = taskPriorities;
            addTaskVm.Projects = projects;
            return addTaskVm;
        }

        public ListTaskForListVm GetAllTasksForList()
        {
            var tasks = _taskRepository.GetAll().ProjectTo<TaskForListVm>(_mapper.ConfigurationProvider).ToList();
            var taskList = new ListTaskForListVm()
            {
                Tasks = tasks,
                Count = tasks.Count
            };
            return taskList; 
        }

        public TaskDetailsVm GetTaskDetails(int taskId)
        {
            var task = _taskRepository.GetTaskById(taskId);
            var tasksVm = _mapper.Map<TaskDetailsVm>(task);
            return tasksVm;        
        }

        public List<TaskCategoriesForListVm> GetTaskCategories()
        {
            var categories = _taskRepository.GetAllTaskCategories().ProjectTo< TaskCategoriesForListVm>(_mapper.ConfigurationProvider).ToList();

            return categories;
        }
        public List<TaskPrioritiesForListVm> GetTaskPriorities()
        {
            var priorities = _taskRepository.GetAllTaskPriorities().ProjectTo<TaskPrioritiesForListVm>(_mapper.ConfigurationProvider).ToList();

            return priorities;
        }

        public void RemoveTask(int taskId)
        {
            _taskRepository.Delete(taskId);
        }

        //        public AddTaskVm GetTaskForEdit(int taskId)
        //        {
        //            _taskRepository.UpdateTask(taskId);

        //        }
    }
}
