using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.Mapping;

namespace TaskFlow.Application.ViewModels.Filter
{
    public class FiltersForListVm : IMapFrom<TaskFlow.Domain.Model.Filter>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TaskFlow.Domain.Model.Filter, FiltersForListVm>().ReverseMap() ;
        }
    }
}
