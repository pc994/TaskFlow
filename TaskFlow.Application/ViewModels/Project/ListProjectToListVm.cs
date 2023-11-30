using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Application.ViewModels.Project
{
    public class ListProjectToListVm
    {
        public List<ProjectForListVm> Projects { get; set; }
        public int Count { get; set; }
    }
}
