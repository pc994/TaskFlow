using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.Mapping;

namespace TaskFlow.Application.ViewModels.Filter
{
    public class FilterProjectVm : IMapFrom<TaskFlow.Domain.Model.FilterProject>
    {
        public int ProjectId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<FilterProjectVm, TaskFlow.Domain.Model.FilterProject>().ReverseMap();
        }
    }
}
