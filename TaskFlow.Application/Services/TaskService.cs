using AutoMapper;
using AutoMapper.QueryableExtensions;
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
            //var taskCategories = _taskRepository.GetAllTaskCategories().ProjectTo<TaskCategoriesForListVm>(_mapper.ConfigurationProvider).ToList();
            //var taskPriorities = _taskRepository.GetAllTaskPriorities().ProjectTo<TaskPrioritiesForListVm>(_mapper.ConfigurationProvider).ToList();
            addTaskVm.Categories = GetTaskCategories();
            addTaskVm.Priorities = GetTaskPriorities();
            addTaskVm.Projects = GetProjectsList();
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
            tasksVm.Priorities = GetTaskPriorities();
            tasksVm.Categories = GetTaskCategories();
            tasksVm.Statuses = GetTaskStauses();
            return tasksVm;
        }

        public List<TaskCategoriesForListVm> GetTaskCategories()
        {
            var categories = _taskRepository.GetAllTaskCategories().ProjectTo<TaskCategoriesForListVm>(_mapper.ConfigurationProvider).ToList();
            return categories;
        }
        public List<TaskPrioritiesForListVm> GetTaskPriorities()
        {
            var priorities = _taskRepository.GetAllTaskPriorities().ProjectTo<TaskPrioritiesForListVm>(_mapper.ConfigurationProvider).ToList();
            return priorities;
        }
        public List<TaskStatusesForListVm> GetTaskStauses()
        {
            var statuses = _taskRepository.GetAllTaskStatuses().ProjectTo<TaskStatusesForListVm>(_mapper.ConfigurationProvider).ToList();
            return statuses;
        }
        public List<ProjectForListVm> GetProjectsList()
        {
            var projects = _projectRepository.GetAllActiveProjects().ProjectTo<ProjectForListVm>(_mapper.ConfigurationProvider).ToList();
            return projects;
        }

        public void RemoveTask(int taskId)
        {
            _taskRepository.Delete(taskId);
        }

        public int AddComment(AddCommentVm addCommentVm)
        {
            addCommentVm.CreatedById = 1;//to implementation later
            addCommentVm.UpdatedById = 1;//to implementation later
            addCommentVm.CreatedDate = DateTime.Now;
            addCommentVm.UpdatedDate = DateTime.Now;
            var comment = _mapper.Map<TaskFlow.Domain.Model.Comment>(addCommentVm);
            _taskRepository.AddComment(comment);
            return comment.TaskId;
        }

        public void UpdatePriority(int taskId, int priorityId)
        {
            _taskRepository.UpdatePriority(taskId,priorityId);
        }

        public void UpdateStatus(int taskId, int statusId)
        {
            _taskRepository.UpdateStatus(taskId, statusId);
        }

        public void UpdateCategory(int taskId, int categoryId)
        {
            _taskRepository.UpdateCategory(taskId, categoryId);
        }

        public AddTaskVm EditTaskView(int taskId)
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
            addTaskVm.Priorities = GetTaskPriorities();
            addTaskVm.Categories = GetTaskCategories();
            addTaskVm.Statuses = GetTaskStauses();
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
