using System;
using System.Collections.Generic;

#nullable disable

namespace MVM.Communications.EFWebAPI.Models
{
    public partial class Profile
    {
        public Profile()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
