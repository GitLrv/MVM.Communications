using System;
using System.Collections.Generic;

#nullable disable

namespace MVM.Communications.EFWebAPI.Models
{
    public partial class MsgContact
    {
        public int Id { get; set; }
        public int MsgRecordSec { get; set; }
        public int ContactId { get; set; }
        public int ContactTypeId { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual ContactType ContactType { get; set; }
        public virtual MsgRecord MsgRecordSecNavigation { get; set; }
    }
}
