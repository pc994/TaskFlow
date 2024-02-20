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
    public class TaskFiltersVm : IMapFrom<TaskFlow.Domain.Model.Task>
    {
        public int Id { get; set; }
        public List<TaskCategoriesForListVm> Categories { get; set; }
        public List<int> CategoriesId { get; set; }
        public List<TaskPrioritiesForListVm> Priorities { get; set; }
        public List<int> PrioritiesId { get; set; }
        public bool IsPublic { get; set; } = true;
        public List<int> ProjectId { get; set; }
        public List<ProjectForListVm> Projects { get; set; }
        public List<int> StatusesId { get; set; }
        public List<TaskStatusesForListVm> Statuses { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TaskFlow.Domain.Model.Task, TaskFiltersVm>();
        }
    }
}
