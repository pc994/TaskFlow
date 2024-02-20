using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.ViewModels.Project;
using TaskFlow.Application.ViewModels.Task;
using TaskFlow.Domain.Model;

namespace TaskFlow.Application.Interfaces
{
    public interface IProjectService
    {
        int AddProject(AddProjectVm addProjectVm);
        AddProjectVm AddProjectView();
        ListProjectToListVm GetAllActiveProjects();
        ListProjectToListVm GetAllInactiveProjects();
        ProjectDetailsVm GetProjectDetails(int projectId);
        AddProjectVm UpdateProjectView(int projectId);
        int UpdateProject(AddProjectVm addProjectVm);
        void EndProject(int projectId);
        bool CheckPossibilityEndProject(int projectId);
        ListTaskForListVm GetActiveTasksByProjectId(int projectId);
        int CountActiveTasksByProjectId(int projectId);
        int CountTasksByProjectId(int projectId);
    }
}
