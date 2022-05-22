using System;
using System.Collections.Generic;

#nullable disable

namespace Task.Models
{
    public partial class Employee
    {
        public long Id { get; set; }
        public int RegionId { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }

        public virtual Region Region { get; set; }
    }
}
