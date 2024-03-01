using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.Mapping;
using TaskFlow.Application.ViewModels.Comment;
using TaskFlow.Domain.Model;

namespace TaskFlow.Application.ViewModels.Task
{
    public class TaskDetailsVm : IMapFrom<TaskFlow.Domain.Model.Task>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public List<TaskStatusesForListVm> Statuses { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<TaskCategoriesForListVm> Categories { get; set; }
        public int PriorityId { get; set; }
        public Priority Priority { get; set; }
        public List<TaskPrioritiesForListVm> Priorities { get; set; }
        public bool IsPublic { get; set; } = true;
        public int ProjectId { get; set; }
        public TaskFlow.Domain.Model.Project Project { get; set; }
        public AddCommentVm AddComment { get; set; }
        public List<CommentsForListVm> Comments { get; set; }
        public int AssignedToId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TaskFlow.Domain.Model.Task, TaskDetailsVm>();
        }
        public class TaskDetailsValidation : AbstractValidator<TaskDetailsVm>
        {
            public TaskDetailsValidation()
            {
                RuleFor(x => x.AddComment.Content).NotNull()
                    .NotEmpty()
                    .Length(2, 500);
            }
        }
    }
}
