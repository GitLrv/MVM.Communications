using System;
using System.Collections.Generic;

#nullable disable

namespace MVM.Communications.EFWebAPI.Models
{
    public partial class Digitalization
    {
        public int Id { get; set; }
        public int MsgRecordSec { get; set; }
        public int MediaTypeId { get; set; }
        public string ResourcePath { get; set; }
        public DateTime? DateCreate { get; set; }

        public virtual MediaType MediaType { get; set; }
        public virtual MsgRecord MsgRecordSecNavigation { get; set; }
    }
}
