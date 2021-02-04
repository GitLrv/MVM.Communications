using System;
using System.Collections.Generic;

#nullable disable

namespace MVM.Communications.EFWebAPI.Models
{
    public partial class Contact
    {
        public Contact()
        {
            MsgContacts = new HashSet<MsgContact>();
            MsgRecords = new HashSet<MsgRecord>();
        }

        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobil { get; set; }
        public int Status { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual ICollection<MsgContact> MsgContacts { get; set; }
        public virtual ICollection<MsgRecord> MsgRecords { get; set; }
    }
}
