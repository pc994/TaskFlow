using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.ViewModels.Task;

namespace TaskFlow.Application.Interfaces
{
    public interface ITaskService
    {
        ListTaskForListVm GetAllTasksForList();
        int AddTask(AddTaskVm addTaskVm);
        TaskDetailsVm GetTaskDetails(int taskId);
    }
}
