using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.Mapping;
using TaskFlow.Application.ViewModels.Project;

namespace TaskFlow.Application.ViewModels.Task
{
    public class AddTaskVm : IMapFrom<TaskFlow.Domain.Model.Task>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int CategoryId { get; set; }
        public List<TaskCategoriesForListVm> Categories { get; set; }
        public int PriorityId { get; set; }
        public List<TaskPrioritiesForListVm> Priorities { get; set; }
        public bool IsPublic { get; set; } = true;
        public int ProjectId { get; set; }
        public List<ProjectForListVm> Projects { get; set; }
        public string AssignedTo { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap< AddTaskVm, TaskFlow.Domain.Model.Task>();
        }

    }
}
