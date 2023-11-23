using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.Mapping;
using Task = TaskFlow.Domain.Model.Task;

namespace TaskFlow.Application.ViewModels.Task
{
    public class TaskForListVm : IMapFrom<TaskFlow.Domain.Model.Task>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Category { get; set; }
        public string Priority { get; set; }
        public string Project { get; set; }
        public string AssignedTo { get; set; } 

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TaskFlow.Domain.Model.Task, TaskForListVm>();
        }
    }
}
