using System;
using System.Collections.Generic;

#nullable disable

namespace MVM.Communications.EFWebAPI.Models
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int OrganizationId { get; set; }

        public virtual Organization Organization { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
