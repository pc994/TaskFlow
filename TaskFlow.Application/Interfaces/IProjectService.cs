using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.ViewModels.Project;

namespace TaskFlow.Application.Interfaces
{
    public interface IProjectService
    {
        ListProjectToListVm GetAllActiveProjects();
    }
}
