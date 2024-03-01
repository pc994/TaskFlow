using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.Mapping;
using TaskFlow.Application.ViewModels.Task;

namespace TaskFlow.Application.ViewModels.Comment
{
    public class AddCommentVm : IMapFrom<TaskFlow.Domain.Model.Comment>
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string? Content { get; set; }
        public int CreatedById { get; set; }
        public int UpdatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsPublic { get; set; } = true;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TaskFlow.Domain.Model.Comment, AddCommentVm>().ReverseMap();
        }
        public class AddCommentValidation : AbstractValidator<AddCommentVm>
        {
            public AddCommentValidation()
            {
                RuleFor(x => x.Content)
                    .NotEmpty()
                    .NotNull()
                    .MinimumLength(1)
                    .MaximumLength(500);
            }
        }
    }
}
