using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.Mapping;
using TaskFlow.Domain.Model;

namespace TaskFlow.Application.ViewModels.Project
{
    public class ProjectDetailsVm : IMapFrom<TaskFlow.Domain.Model.Project>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int TasksCount { get; set; }
        public ProjectDetail ProjectDetail { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TaskFlow.Domain.Model.Project, ProjectDetailsVm>();
        }
    }
}
