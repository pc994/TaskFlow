using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Domain.Model
{
    public class TaskTag
    {
        //m:n (2x1:n) 
        public int TaskId { get; set; }
        public Task Task { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
