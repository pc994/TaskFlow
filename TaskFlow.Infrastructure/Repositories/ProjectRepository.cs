using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain.Model;

namespace TaskFlow.Infrastructure.Repositories
{
    public class ProjectRepository
    {
        private readonly DbContext _dbContext;
        public ProjectRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Add(Project project) 
        {
            _dbContext.Projects.Add(project);
            return project.Id;
        }
    }
}
