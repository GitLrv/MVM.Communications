using System;
using System.Collections.Generic;

#nullable disable

namespace MVM.Communications.EFWebAPI.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Contacts = new HashSet<Contact>();
        }

        public int Id { get; set; }
        public int ProfileId { get; set; }
        public int DepartmentId { get; set; }
        public bool Active { get; set; }

        public virtual Department Department { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
