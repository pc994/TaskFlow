using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.Mapping;

namespace TaskFlow.Application.ViewModels.Filter
{
    public class FilterPriorityVm : IMapFrom<TaskFlow.Domain.Model.FilterPriority>
    {
        public int PriorityId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<FilterPriorityVm, TaskFlow.Domain.Model.FilterPriority>().ReverseMap();
        }
    }
}
