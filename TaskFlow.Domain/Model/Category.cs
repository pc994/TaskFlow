using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Domain.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //1:n
        public ICollection<Task> Tasks { get; set; }
        //n:n
        public ICollection<FilterCategory> FilterCategories { get; set; }
    }
}
