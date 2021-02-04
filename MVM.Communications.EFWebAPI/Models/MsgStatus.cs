using System;
using System.Collections.Generic;

#nullable disable

namespace MVM.Communications.EFWebAPI.Models
{
    public partial class MsgStatus
    {
        public MsgStatus()
        {
            MsgRecords = new HashSet<MsgRecord>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MsgRecord> MsgRecords { get; set; }
    }
}
