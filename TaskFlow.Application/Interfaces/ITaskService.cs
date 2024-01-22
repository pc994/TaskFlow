using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.ViewModels.Comment;
using TaskFlow.Application.ViewModels.Task;

namespace TaskFlow.Application.Interfaces
{
    public interface ITaskService
    {
        ListTaskForListVm GetAllTasksForList();
        int AddTask(AddTaskVm addTaskVm);
        AddTaskVm AddTaskView();
        TaskDetailsVm GetTaskDetails(int taskId);
        //List<TaskCategoriesForListVm> GetTaskCategories();
        //List<TaskPrioritiesForListVm> GetTaskPriorities();
        void RemoveTask(int taskId);
        int AddComment(AddCommentVm addCommentVm);
        void UpdatePriority(int taskId, int priorityId);
        void UpdateStatus(int taskId, int statusId);
        void UpdateCategory(int taskId, int categoryId);
        AddTaskVm EditTaskView(int taskId);
        int UpdateTask(AddTaskVm taskModel);
    }
}
