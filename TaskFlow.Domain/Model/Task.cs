using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Domain.Model
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
        public int CategoryId { get; set; }
        public int PriorityId { get; set; }
        public bool IsPublic { get; set; } = true;
        public int ProjectId { get; set; }
        public int AssignedToId { get; set; }
        
        //1:1
        public TaskAuditableModel TaskAuditableModel  { get; set; }
        //1:n
        public virtual Project Project { get; set; }
        //1:n
        public Status Status { get; set; }
        //1:n
        public Category Category { get; set; }
        //1:n
        public Priority Priority { get; set; }
        //1:n
        public ICollection<Comment> Comments { get; set; }
        //m:n (2x1:n)
        public ICollection<TaskTag> TaskTags { get; set; }

    }
}
