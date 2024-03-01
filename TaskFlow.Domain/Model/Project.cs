using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskFlow.Domain.Model
{
    public class Project 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; } 
        //1:1
        public ProjectDetail ProjectDetail { get; set; }
        //1:n
        public ICollection<Task> Tasks { get; set; }
        //n:n
        public ICollection<FilterProject> FilterProjects { get; set; }
    }
}
