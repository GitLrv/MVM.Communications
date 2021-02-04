using System;
using System.Collections.Generic;

#nullable disable

namespace MVM.Communications.EFWebAPI.Models
{
    public partial class MediaType
    {
        public MediaType()
        {
            Digitalizations = new HashSet<Digitalization>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Digitalization> Digitalizations { get; set; }
    }
}
