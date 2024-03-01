using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Domain.Model
{
    public class Filter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //n:n 
        public ICollection<FilterCategory> FilterCategories { get; set; }
        public ICollection<FilterStatus> FilterStatuses { get; set; }
        public ICollection<FilterPriority> FilterPriorities { get; set; }
        public ICollection<FilterProject> FilterProjects { get; set; }
    }
}
