﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.Mapping;
using TaskFlow.Domain.Model;
using Task = TaskFlow.Domain.Model.Task;

namespace TaskFlow.Application.ViewModels.Task
{
    public class TaskForListVm : IMapFrom<TaskFlow.Domain.Model.Task>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int PriorityId { get; set; }
        public Priority Priority { get; set; }        
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public bool IsPublic { get; set; } = true;
        public int ProjectId { get; set; }
        public int AssignedToId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TaskFlow.Domain.Model.Task, TaskForListVm>();
        }
    }
}
