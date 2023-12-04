using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.Mapping;
using TaskFlow.Domain.Model;

namespace TaskFlow.Application.ViewModels.Task
{
    public class TaskDetailsVm : IMapFrom<TaskFlow.Domain.Model.Task>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TaskFlow.Domain.Model.Task, TaskDetailsVm>();
        }
    }
}
