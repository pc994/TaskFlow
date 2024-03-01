using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Domain.Model
{
    public class FilterProject
    {
        public int FilterId { get; set; }
        public Filter Filter { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
