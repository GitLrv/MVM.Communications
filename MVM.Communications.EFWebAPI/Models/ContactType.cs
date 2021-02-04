using System;
using System.Collections.Generic;

#nullable disable

namespace MVM.Communications.EFWebAPI.Models
{
    public partial class ContactType
    {
        public ContactType()
        {
            MsgContacts = new HashSet<MsgContact>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MsgContact> MsgContacts { get; set; }
    }
}
