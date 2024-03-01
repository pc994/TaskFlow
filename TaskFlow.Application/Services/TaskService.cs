using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;
using TaskFlow.Application.Interfaces;
using TaskFlow.Application.ViewModels.Comment;
using TaskFlow.Application.ViewModels.Filter;
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

        public ListTaskForListVm GetTasksForList(int pageSize, int pageNo, string searchString, TaskFiltersVm taskFiltersVm)
        {
            var filteredTasks = SetTasksFiltersByFilterId(taskFiltersVm.Id);
            filteredTasks.Filters = GetUserFilters(); //get filters for list from db
            var tasks = _taskRepository.GetAllTasks()
                .Where(t =>
            (t.Name.Contains(searchString) ||
            t.Description.Contains(searchString) ||
            t.Comments.Any(c => c.Content.Contains(searchString))) &&
             filteredTasks.FilterCategoriesIds.Contains(t.CategoryId) &&
             filteredTasks.FilterPrioritiesIds.Contains(t.PriorityId) &&
             filteredTasks.FilterProjectsIds.Contains(t.ProjectId) &&
             filteredTasks.FilterStatusesIds.Contains(t.StatusId))
              .ProjectTo<TaskForListVm>(_mapper.ConfigurationProvider)
               .ToList();
            var tasksToShow = tasks.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
            var listOfTasks = new ListTaskForListVm()
            {
                CurrentPage = pageNo,
                PageSize = pageSize,
                SearchString = searchString,
                Tasks = tasksToShow,
                Count = tasks.Count,
                TaskFilters = filteredTasks,
            };
            return listOfTasks;
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
            addTaskVm.Statuses = GetParameters<Status, TaskStatusesForListVm>().Where(t => t.Name != "Closed").ToList();
            addTaskVm.Projects = GetProjectsList();
            return addTaskVm;
        }

        public int UpdateTask(AddTaskVm taskModel)
        {
            var task = _mapper.Map<TaskFlow.Domain.Model.Task>(taskModel);
            var taskId = _taskRepository.UpdateTask(task);
            return taskId;
        }

        public void SaveFilters(TaskFiltersVm filterVm)
        {
            AddFilterVm addFilter = new AddFilterVm()
            {
                Name = filterVm.Name,
                FilterCategories = filterVm.FilterCategoriesIds.Select(c => new FilterCategoryVm { CategoryId = c }).ToList(),
                FilterStatuses = filterVm.FilterStatusesIds.Select(s => new FilterStatusVm { StatusId = s }).ToList(),
                FilterPriorities = filterVm.FilterPrioritiesIds.Select(p => new FilterPriorityVm { PriorityId = p }).ToList(),
                FilterProjects = filterVm.FilterProjectsIds.Select(p => new FilterProjectVm { ProjectId = p }).ToList(),
            };
            var filter = _mapper.Map<TaskFlow.Domain.Model.Filter>(addFilter);
            _taskRepository.SaveFilter(filter);
        }

        private TaskFiltersVm SetTasksFiltersByFilterId(int filterId)
        {
            TaskFiltersVm taskFilters = new TaskFiltersVm();
            InitListsOfFiltersParams(taskFilters);
            if (filterId == 0)
            {
                SetAllDefaultFilterIds(taskFilters);
            }
            else
            {
                var filter = _taskRepository.GetFilterDetailsByFilterId(filterId);
                taskFilters = _mapper.Map<TaskFiltersVm>(filter);
                InitListsOfFiltersParams(taskFilters);
                SetFilterIdsByFilter(taskFilters);
            }
            return taskFilters;
        }

        private void SetFilterIdsByFilter(TaskFiltersVm taskFilters)
        {
            taskFilters.FilterCategoriesIds = taskFilters.FilterCategories.Select(c => c.CategoryId).ToList();
            taskFilters.FilterPrioritiesIds = taskFilters.FilterPriorities.Select(p => p.PriorityId).ToList();
            taskFilters.FilterProjectsIds = taskFilters.FilterProjects.Select(p => p.ProjectId).ToList();
            taskFilters.FilterStatusesIds = taskFilters.FilterStatuses.Select(s => s.StatusId).ToList();
        }

        private void SetAllDefaultFilterIds(TaskFiltersVm taskFiltersVm)
        {
            taskFiltersVm.FilterCategoriesIds = GetParameters<Category, TaskCategoriesForListVm>().Select(c => c.Id).ToList();
            taskFiltersVm.FilterProjectsIds = GetParameters<Project, ProjectForListVm>().Select(p => p.Id).ToList();
            taskFiltersVm.FilterPrioritiesIds = GetParameters<Priority, TaskPrioritiesForListVm>().Select(p => p.Id).ToList();
            taskFiltersVm.FilterStatusesIds = GetParameters<Status, TaskStatusesForListVm>().Select(s => s.Id).ToList();
        }

        private TaskFiltersVm InitListsOfFiltersParams(TaskFiltersVm taskFiltersVm)
        {
            taskFiltersVm.Categories = GetParameters<Category, TaskCategoriesForListVm>().ToList();
            taskFiltersVm.Statuses = GetParameters<Status, TaskStatusesForListVm>().ToList();
            taskFiltersVm.Priorities = GetParameters<Priority, TaskPrioritiesForListVm>().ToList();
            taskFiltersVm.Projects = GetParameters<Project, ProjectForListVm>().ToList();
            return taskFiltersVm;
        }

        private List<FiltersForListVm> GetUserFilters()
        {
            var filters = _taskRepository.GetUserFilter().ProjectTo<FiltersForListVm>(_mapper.ConfigurationProvider).ToList();
            var defaultFilter = new FiltersForListVm()
            {
                Id = 0,
                Name = "--default--"
            };
            filters.Insert(0, defaultFilter);
            return filters;
        }

        private List<ProjectForListVm> GetProjectsList()
        {
            var projects = _projectRepository.GetAllActiveProjects().ProjectTo<ProjectForListVm>(_mapper.ConfigurationProvider).ToList();
            return projects;
        }
    }
}
