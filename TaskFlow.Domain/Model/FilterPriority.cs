using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Domain.Model
{
    public class FilterPriority
    {
        public int FilterId { get; set; }
        public Filter Filter { get; set; }
        public int PriorityId { get; set; }
        public Priority Priority { get; set; }
    }
}
