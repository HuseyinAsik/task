using System;
using System.Collections.Generic;

#nullable disable

namespace Task.Models
{
    public partial class Region
    {
        public Region()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
