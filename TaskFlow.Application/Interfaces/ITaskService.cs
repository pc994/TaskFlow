using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.ViewModels.Comment;
using TaskFlow.Application.ViewModels.Filter;
using TaskFlow.Application.ViewModels.Task;

namespace TaskFlow.Application.Interfaces
{
    public interface ITaskService
    {
        ListTaskForListVm GetTasksForList(int pageSize, int pageNo, string searchString, TaskFiltersVm taskFiltersVm);
        int AddTask(AddTaskVm addTaskVm);
        AddTaskVm AddTaskView();
        TaskDetailsVm GetTaskDetails(int taskId);
        List<TViewModel> GetParameters<T, TViewModel>() where T : class;
        int AddComment(AddCommentVm addCommentVm);
        void UpdateStatus(int taskId, int statusId);
        AddTaskVm UpdateTaskView(int taskId);
        int UpdateTask(AddTaskVm taskModel);
        void SaveFilters(TaskFiltersVm filterVm);
    }
}
