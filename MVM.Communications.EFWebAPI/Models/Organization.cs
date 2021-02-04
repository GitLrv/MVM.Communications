using System;
using System.Collections.Generic;

#nullable disable

namespace MVM.Communications.EFWebAPI.Models
{
    public partial class Organization
    {
        public Organization()
        {
            Departments = new HashSet<Department>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
    }
}
