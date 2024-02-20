using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;
using TaskFlow.Application.Interfaces;
using TaskFlow.Application.ViewModels.Comment;
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
            task.StatusId = 1;
            var id = _taskRepository.AddTask(task);
            return id;
        }
        public AddTaskVm AddTaskView()
        {
            AddTaskVm addTaskVm = new AddTaskVm();
            addTaskVm.Categories = GetParameters<Category, TaskCategoriesForListVm>(); 
            addTaskVm.Priorities = GetParameters<Priority, TaskPrioritiesForListVm>(); 
            addTaskVm.Projects = GetProjectsList();
            return addTaskVm;
        }
        public TaskFiltersVm TaskFiltersView()
        {
            TaskFiltersVm taskFiltersVm = new TaskFiltersVm();
            taskFiltersVm.Categories = GetParameters<Category, TaskCategoriesForListVm>(); ;
            taskFiltersVm.Statuses = GetParameters<Status, TaskStatusesForListVm>(); ;
            taskFiltersVm.Priorities = GetParameters<Priority, TaskPrioritiesForListVm>(); ;
            taskFiltersVm.Projects = GetProjectsList();
            return taskFiltersVm;
        }
        public ListTaskForListVm GetAllTasksForList()
        {
            var tasks = _taskRepository.GetAll().ProjectTo<TaskForListVm>(_mapper.ConfigurationProvider).ToList();
            var listOfTasks = new ListTaskForListVm()
            {
                Tasks = tasks,
                Count = tasks.Count
            };
            return listOfTasks;
        }
        public ListTaskForListVm GetAllActiveTasksForList(int pageSize, int pageNo, string searchString, TaskFiltersVm taskFiltersVm)
        {

            if (taskFiltersVm.CategoriesId is null)
            {
                taskFiltersVm.CategoriesId = GetParameters<Category, TaskCategoriesForListVm>().Select(t => t.Id).ToList();
            }
            if (taskFiltersVm.StatusesId is null)
            {
                taskFiltersVm.StatusesId = GetParameters<Status, TaskStatusesForListVm>().Select(t => t.Id).ToList();
            }
            if (taskFiltersVm.PrioritiesId is null)
            {
                taskFiltersVm.PrioritiesId = GetParameters<Priority, TaskPrioritiesForListVm>().Select(t => t.Id).ToList();
            }
            if (taskFiltersVm.ProjectId is null)
            {
                taskFiltersVm.ProjectId = GetParameters<Project, ProjectForListVm>().Select(t => t.Id).ToList();
            }
            var tasks = _taskRepository.GetAllTasks()
                .Where(t =>
            (t.Name.Contains(searchString) ||
            t.Description.Contains(searchString) ||
            t.Comments.Any(c => c.Content.Contains(searchString))) &&(
            taskFiltersVm.CategoriesId.Contains(t.CategoryId)) &&
            taskFiltersVm.StatusesId.Contains(t.StatusId) &&
            (taskFiltersVm.PrioritiesId.Contains(t.PriorityId)) &&
            (taskFiltersVm.ProjectId.Contains(t.ProjectId))            )
              .ProjectTo<TaskForListVm>(_mapper.ConfigurationProvider)
               .ToList();

            var tasksToShow = tasks.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
            taskFiltersVm.Categories = GetParameters<Category, TaskCategoriesForListVm>();
            taskFiltersVm.Statuses = GetParameters<Status, TaskStatusesForListVm>();
            taskFiltersVm.Priorities = GetParameters<Priority, TaskPrioritiesForListVm>();
            taskFiltersVm.Projects = GetParameters<Project, ProjectForListVm>();

            var listOfTasks = new ListTaskForListVm()
            {
                CurrentPage = pageNo,
                PageSize = pageSize,
                SearchString = searchString,
                Tasks = tasksToShow,
                Count = tasks.Count,
                TaskFilters = taskFiltersVm,
            };
            return listOfTasks;
        }
        public TaskDetailsVm GetTaskDetails(int taskId)
        {
            var task = _taskRepository.GetTaskById(taskId);

            var taskVm = _mapper.Map<TaskDetailsVm>(task);
            taskVm.Statuses = GetParameters<Status, TaskStatusesForListVm>();
            return taskVm;
        }
        public List<TViewModel> GetParameters<T, TViewModel>() where T : class
        {
            var entities = _taskRepository.GetParameters<T>().ProjectTo<TViewModel>(_mapper.ConfigurationProvider).ToList();
            return entities;
        }
        public List<ProjectForListVm> GetProjectsList()
        {
            var projects = _projectRepository.GetAllActiveProjects().ProjectTo<ProjectForListVm>(_mapper.ConfigurationProvider).ToList();
            return projects;
        }
        public int AddComment(AddCommentVm addCommentVm)
        {
            addCommentVm.CreatedById = 1;//to implementation later(users module)
            addCommentVm.UpdatedById = 1;//to implementation later(users module)
            addCommentVm.CreatedDate = DateTime.Now;
            addCommentVm.UpdatedDate = DateTime.Now;
            var comment = _mapper.Map<TaskFlow.Domain.Model.Comment>(addCommentVm);
            _taskRepository.AddComment(comment);
            return comment.TaskId;
        }
        public void UpdateStatus(int taskId, int statusId)
        {
            _taskRepository.UpdateStatus(taskId, statusId);
        }
        public AddTaskVm UpdateTaskView(int taskId)
        {
            var task = GetTaskDetails(taskId);
            AddTaskVm addTaskVm = new AddTaskVm();
            addTaskVm.Id = task.Id;
            addTaskVm.Name = task.Name;
            addTaskVm.Description = task.Description;
            addTaskVm.CategoryId = task.CategoryId;
            addTaskVm.StatusId = task.StatusId;
            addTaskVm.PriorityId = task.PriorityId;
            addTaskVm.IsPublic = task.IsPublic;
            addTaskVm.ProjectId = task.ProjectId;
            addTaskVm.Priorities = GetParameters<Priority, TaskPrioritiesForListVm>();
            addTaskVm.Categories = GetParameters<Category, TaskCategoriesForListVm>();
            addTaskVm.Statuses = GetParameters<Status, TaskStatusesForListVm>().Where(t=>t.Name != "Closed").ToList();
            addTaskVm.Projects = GetProjectsList();
            return addTaskVm;
        }
        public int UpdateTask(AddTaskVm taskModel)
        {
            var task = _mapper.Map<TaskFlow.Domain.Model.Task>(taskModel);
            var taskId = _taskRepository.UpdateTask(task);
            return taskId;
        }
    }
}
