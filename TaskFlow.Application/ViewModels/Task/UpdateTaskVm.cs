using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Application.ViewModels.Task
{
    public class UpdateTaskVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Category { get; set; }
        public string Priority { get; set; }
        public bool IsPublic { get; set; } = true;
        public string ProjectName { get; set; }
        public string AssignedTo { get; set; }
    }
}
