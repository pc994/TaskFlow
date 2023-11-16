using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.Interfaces;
using TaskFlow.Application.ViewModels.Task;
using TaskFlow.Domain.Interfaces;
using TaskFlow.Domain.Model;

namespace TaskFlow.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        public int AddTask(AddTaskVm addTaskVm)
        {
            throw new NotImplementedException();
        }

        public ListTaskForListVm GetAllTasksForList()
        {
            var tasks = _taskRepository.GetAll();
            ListTaskForListVm tasksForListVm = new ListTaskForListVm();
            tasksForListVm.Tasks = new List<TaskForListVm>();
            foreach (var task in tasks)
            {
                var taskVm = new TaskForListVm()
                {
                    Id = task.Id,
                    Name = task.Name,
                    Category = "Category",
                    Status = "Status",
                    Priority = "Priority",
                    AssignedTo = "AssignedTo",
                    Project = "ProjectName"
                };
                tasksForListVm.Tasks.Add(taskVm);
            }
            tasksForListVm.Count = tasksForListVm.Tasks.Count;
            return tasksForListVm;
        }

        public TaskDetailsVm GetTaskDetails(int taskId)
        {
            var task = _taskRepository.GetTaskById(taskId);
            TaskDetailsVm taskDetailsVm = new TaskDetailsVm()
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description
            };
            return taskDetailsVm;           
        }
    }
}
