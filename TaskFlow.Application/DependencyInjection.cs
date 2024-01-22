using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.Interfaces;
using TaskFlow.Application.Services;
using TaskFlow.Application.ViewModels.Comment;
using TaskFlow.Application.ViewModels.Task;
using TaskFlow.Domain.Interfaces;
using static TaskFlow.Application.ViewModels.Comment.AddCommentVm;
using static TaskFlow.Application.ViewModels.Task.AddTaskVm;


namespace TaskFlow.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<ITaskService, TaskService>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<IValidator<AddTaskVm>, AddTaskValidation>();
            services.AddTransient<IValidator<AddCommentVm>, AddCommentValidation>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
