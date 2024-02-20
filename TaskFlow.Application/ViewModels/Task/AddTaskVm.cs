using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        public int StatusId { get; set; }
        public List<TaskStatusesForListVm> Statuses { get; set; }
        public string AssignedTo { get; set; } //To implementation later / users module

        public void Mapping(Profile profile)
        {
            profile.CreateMap< AddTaskVm, TaskFlow.Domain.Model.Task>();
        }
        public class AddTaskValidation : AbstractValidator<AddTaskVm>
        {
            public AddTaskValidation()
            {
                RuleFor(x => x.Id).NotNull();
                RuleFor(x => x.Name)
                    .NotNull()
                    .Length(3,40);
                RuleFor(x => x.Description)
                    .NotNull()
                    .NotEmpty()
                    .Length(1,2000);
            } 
        }
    }
}
