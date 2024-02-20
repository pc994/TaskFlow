using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.ViewModels.Project;

namespace TaskFlow.Application.ViewModels.Task
{
    public class ListTaskForListVm
    {
        public List<TaskForListVm> Tasks { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public int Count { get; set; }
        public TaskFiltersVm TaskFilters { get; set; }
    }
}
