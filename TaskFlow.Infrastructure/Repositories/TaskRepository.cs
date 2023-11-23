using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskFlow.Domain.Interfaces;
using Task = TaskFlow.Domain.Model.Task;

namespace TaskFlow.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly Context _dbContext;
        public TaskRepository(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public int Add(Task task)
        {
            _dbContext.Tasks.Add(task);
            _dbContext.SaveChanges();
            return task.Id;
        }

        public void Delete(int taskId) 
        {
            var task = _dbContext.Tasks.Find(taskId);
            if(task != null)
            {
                _dbContext.Tasks.Remove(task);
                _dbContext.SaveChanges();
            }
        }

        public IQueryable<Task> GetAll()
        {
            return _dbContext.Tasks;
        }

        public Task GetTaskById(int taskId) 
        {
            var task = _dbContext.Tasks.FirstOrDefault(t => t.Id == taskId);
            return task;
        }

        public IQueryable<Task> GetTaskByCategoryId(int categoryId)
        {
            var tasks = _dbContext.Tasks.Where(t=>t.CategoryId == categoryId);
            return tasks;
        }

        public IQueryable<Task> GetTasksByStatusId(int statusId)
        {
            var tasks = _dbContext.Tasks.Where(t=>t.StatusId == statusId);
            return tasks;
        }

        public IQueryable<Task> GetTasksByPriorityId(int priorityId)
        {
            var tasks = _dbContext.Tasks.Where(t=>t.ProjectId == priorityId);
            return tasks;
        }

        public IQueryable<Task> GetTaskByAssignedToId(int assignedToId)
        {
            var tasks = _dbContext.Tasks.Where(t=>t.AssignedToId == assignedToId);
            return tasks;
        }

        public IQueryable<Task> GetTaskByProjectId(int projectId)
        {
            var tasks = _dbContext.Tasks.Where(t=>t.ProjectId != projectId);
            return tasks;
        }

        public IQueryable<Task> GetPublicOrPrivateTasks(bool isPublic)
        {
            var tasks = _dbContext.Tasks.Where(t => t.IsPublic == isPublic);
            return tasks;
        }
    }
}
