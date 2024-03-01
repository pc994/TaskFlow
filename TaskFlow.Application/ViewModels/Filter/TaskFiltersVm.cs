using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.Mapping;
using TaskFlow.Application.ViewModels.Project;
using TaskFlow.Application.ViewModels.Task;

namespace TaskFlow.Application.ViewModels.Filter
{
    public class TaskFiltersVm : IMapFrom<Domain.Model.Filter>
    {
        public int Id { get; set; } 
        public string Name { get; set; } 
        public List<FiltersForListVm> Filters { get; set; }
        public List<TaskCategoriesForListVm> Categories { get; set; }
        public List<FilterCategoryVm> FilterCategories { get; set; }
        public List<int> FilterCategoriesIds { get; set; }
        public List<TaskPrioritiesForListVm> Priorities { get; set; }
        public List<FilterPriorityVm> FilterPriorities { get; set; }
        public List<int> FilterPrioritiesIds { get; set; }
        public List<ProjectForListVm> Projects { get; set; }
        public List<FilterProjectVm> FilterProjects { get; set; }
        public List<int> FilterProjectsIds { get; set; }
        public List<TaskStatusesForListVm> Statuses { get; set; }
        public List<FilterStatusVm> FilterStatuses { get; set; }
        public List<int> FilterStatusesIds { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<TaskFiltersVm, TaskFlow.Domain.Model.Filter>().ReverseMap();
        }
    }
}
