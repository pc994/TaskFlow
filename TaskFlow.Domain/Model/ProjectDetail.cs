using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Domain.Model
{
    public class ProjectDetail
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string CEOName { get; set; }
        public string ZipCode { get; set; }
        public DateOnly StartProject { get; set; }  
        public DateOnly EndProject { get; set; }
        //1:1
        public int ProjectId { get; set;}
        //1:1
        public Project Project { get; set; }

    }
}
