using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Domain.Model
{
    public class Comment
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string Content { get; set; }
        public int CreatedById { get; set; }
        public int UpdatedById { get; set; }
        public DateTime CreatedDate { get; set;}
        public DateTime UpdatedDate { get; set;}
        public bool IsPublic { get; set; } = true;
        //1:n
        public Task Task { get; set; }
    }
}
