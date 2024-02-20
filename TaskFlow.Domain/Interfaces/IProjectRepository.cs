using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain.Model;

namespace TaskFlow.Domain.Interfaces
{
    public interface IProjectRepository
    {
        public IQueryable<Project> GetAllActiveProjects();
        public IQueryable<Project> GetAllInactiveProjects();
        int AddProject(Project projectDetail);
        void EndProject(int projectId);
        Project GetProjectById(int projectId);
        ProjectDetail GetProjectDetailsById(int projectId);
        int UpdateProject(Project project);
    }
}
