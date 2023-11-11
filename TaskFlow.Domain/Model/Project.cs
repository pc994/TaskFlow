using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Domain.Model
{
    public class Project 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
        //1:1
        public ProjectDetail ProjectDetail { get; set; }
        //1:n
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
