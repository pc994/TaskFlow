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

        int GetTaskCategoryIdByName(string name);


    }
}
