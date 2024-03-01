using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskFlow.Domain.Model;
using Task = TaskFlow.Domain.Model.Task;

namespace TaskFlow.Domain.Interfaces
{
    public interface ITaskRepository
    {
        int AddTask(Task task);
        void Delete(int taskId);
        IQueryable<Task> GetAll();
        Task GetTaskById(int taskId);
        IQueryable<Task> GetTaskByCategoryId(int categoryId);
        IQueryable<Task> GetTasksByStatusId(int statusId);
        IQueryable<Task> GetTasksByPriorityId(int priorityId);
        IQueryable<Task> GetTaskByAssignedToId(int assignedToId);
        IQueryable<Task> GetTaskByProjectId(int projectId);
        IQueryable<Task> GetPublicOrPrivateTasks(bool isPublic);
        IQueryable<Category> GetAllTaskCategories();
        IQueryable<Priority> GetAllTaskPriorities();
        IQueryable<Status> GetAllTaskStatuses();
        int GetTaskCategoryIdByName(string name);
        string GetTaskStatusNameByStatusId(int id);
        void AddComment(Comment comment);
        void UpdatePriority(int taskId, int priorityId);
        void UpdateStatus(int taskId, int statusId);
        void UpdateCategory(int taskId, int categoryId);
        int UpdateTask(Task task);
        IQueryable<Task> GetActiveTasksByProjectId(int projectId);
        int CountActiveTasksByProjectId(int projectId);
        int CountTasksByProjectId(int projectId);
        IQueryable<Task> GetAllTasks();
        IQueryable<T> GetParameters<T>() where T : class;
        void SaveFilter(Filter filter);
        IQueryable<Filter> GetUserFilter();
        Filter GetFilterDetailsByFilterId(int filterId);
    }
}
