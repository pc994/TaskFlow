using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.Mapping;

namespace TaskFlow.Application.ViewModels.Filter
{
    public class FilterStatusVm : IMapFrom<TaskFlow.Domain.Model.FilterStatus>
    {
        public int StatusId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<FilterStatusVm, TaskFlow.Domain.Model.FilterStatus>().ReverseMap();
        }
    }
}
