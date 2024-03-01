using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.Mapping;

namespace TaskFlow.Application.ViewModels.Comment
{
    public class CommentsForListVm : IMapFrom<TaskFlow.Domain.Model.Comment>
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string Content { get; set; }
        public int CreatedById { get; set; }
        public int UpdatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsPublic { get; set; } = true;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TaskFlow.Domain.Model.Comment, CommentsForListVm>();
        }
    }
}
