using System;
using System.Collections.Generic;

#nullable disable

namespace MVM.Communications.EFWebAPI.Models
{
    public partial class ConsecutiveControl
    {
        public int Id { get; set; }
        public int MsgTypeId { get; set; }
        public string Prefix { get; set; }
        public int Sec { get; set; }
        public int ConsecutiveLength { get; set; }
        public DateTime DateControl { get; set; }

        public virtual MsgType MsgType { get; set; }
    }
}
