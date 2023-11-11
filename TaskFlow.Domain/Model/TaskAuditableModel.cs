using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Domain.Model
{
    public class TaskAuditableModel
    {
        public int Id { get; set; }
        public int CreatedById { get; set; }
        public int UpdatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        //1:1
        public int TaskId { get; set; }
        //1:1
        public Task Task { get; set; }
    }
}
