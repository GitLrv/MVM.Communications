using System;
using System.Collections.Generic;

#nullable disable

namespace MVM.Communications.EFWebAPI.Models
{
    public partial class MsgRecord
    {
        public MsgRecord()
        {
            Digitalizations = new HashSet<Digitalization>();
            MsgContacts = new HashSet<MsgContact>();
        }

        public int Id { get; set; }
        public string Prefix { get; set; }
        public int Sec { get; set; }
        public int DocManagerContactId { get; set; }
        public DateTime ReceivedDate { get; set; }
        public DateTime? DeliveredDate { get; set; }
        public int MsgTypeId { get; set; }
        public bool Digitalization { get; set; }
        public int MsgStatusId { get; set; }

        public virtual Contact DocManagerContact { get; set; }
        public virtual MsgStatus MsgStatus { get; set; }
        public virtual MsgType MsgType { get; set; }
        public virtual ICollection<Digitalization> Digitalizations { get; set; }
        public virtual ICollection<MsgContact> MsgContacts { get; set; }
    }
}
