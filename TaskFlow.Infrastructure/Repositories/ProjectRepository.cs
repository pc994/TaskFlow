using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain.Interfaces;
using TaskFlow.Domain.Model;

namespace TaskFlow.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly Context _dbContext;
        public ProjectRepository(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public int AddProject(Project project) 
        {
            _dbContext.Projects.Add(project);
            _dbContext.SaveChanges();
            return project.Id;
        }
        public void EndProject(int projectId)
        {
            var project = _dbContext.Projects.Include(p=>p.ProjectDetail).FirstOrDefault(p => p.Id == projectId);
            if (project != null)
            {
                project.IsActive = false;
                project.ProjectDetail.EndProject = DateTime.Now;
                _dbContext.Update(project);
                _dbContext.SaveChanges();
            }
        }
        public IQueryable<Project> GetAllActiveProjects()
        {
            return _dbContext.Projects.Where(p => p.IsActive == true);
        }

        public Project GetProjectById(int projectId)
        {
            return _dbContext.Projects
                .Include(p=>p.ProjectDetail)
                .FirstOrDefault(p=>p.Id == projectId);
        }

        public ProjectDetail GetProjectDetailsById(int projectId)
        {        
            return _dbContext.ProjectDetails.Find(projectId);
        }

        public int UpdateProject(Project project)
        {
            _dbContext.Projects.Update(project);
            _dbContext.SaveChanges();
            return project.Id;
        }

        public IQueryable<Project> GetAllInactiveProjects()
        {
            return _dbContext.Projects.Where(p => p.IsActive == false);
        }
    }
}
