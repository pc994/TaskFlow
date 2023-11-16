using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Application.ViewModels.Task
{
    public class ListTaskForListVm
    {
        public List<TaskForListVm> Tasks { get; set; }
        public int Count { get; set; }
    }
}
