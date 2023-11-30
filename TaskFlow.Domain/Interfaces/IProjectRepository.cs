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
        int Add(Project project);
        public IQueryable<Project> GetAllActiveProjects();
    }
}
