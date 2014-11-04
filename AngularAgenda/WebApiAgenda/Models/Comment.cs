using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace WebApiAgenda.Models
{
    public partial class comment
    {
        public global::System.Int32 id { get; set; }

        [DataType(DataType.MultilineText)]
        public global::System.String description { get; set; }

        public global::System.Int32 event_id { get; set; }

        public global::System.Int32 user_id { get; set; }

        public aevent aevent { get; set; }

        public user user { get; set; }
        public List<friend> friends { get; set; }
        public List<friend> friends1 { get; set; }
        public List<comment> comments { get; set; }
    }
}
