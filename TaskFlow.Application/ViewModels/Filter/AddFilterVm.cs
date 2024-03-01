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
using TaskFlow.Domain.Model;

namespace TaskFlow.Application.ViewModels.Filter
{
    public class AddFilterVm : IMapFrom<TaskFlow.Domain.Model.Filter>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<FilterCategoryVm> FilterCategories { get; set; }
        public List<FilterStatusVm> FilterStatuses { get; set; }
        public List<FilterProjectVm> FilterProjects { get; set; }
        public List<FilterPriorityVm> FilterPriorities { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AddFilterVm, TaskFlow.Domain.Model.Filter>();
        }
    }
}
