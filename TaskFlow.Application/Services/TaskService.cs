using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        private readonly IMapper _mapper;
        public int AddTask(AddTaskVm addTaskVm)
        {
            throw new NotImplementedException();
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
