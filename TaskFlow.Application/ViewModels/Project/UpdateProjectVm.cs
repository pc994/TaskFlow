using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Application.ViewModels.Project
{
    public class UpdateProjectVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string CEOName { get; set; }
        public string ZipCode { get; set; }
        public DateTime StartProject { get; set; }
    }
}
