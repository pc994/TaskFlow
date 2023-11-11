using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Domain.Model
{
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //1:n
        public ICollection<Task> Tasks { get; set; }
    }
}
