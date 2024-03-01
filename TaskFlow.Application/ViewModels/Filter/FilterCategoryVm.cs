using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.Mapping;

namespace TaskFlow.Application.ViewModels.Filter
{
    public class FilterCategoryVm : IMapFrom<TaskFlow.Domain.Model.FilterCategory>
    {
        public int CategoryId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<FilterCategoryVm, TaskFlow.Domain.Model.FilterCategory>().ReverseMap();
        }
    }
}
