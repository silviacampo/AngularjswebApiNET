using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebApiAgenda.Models
{
    public partial class friend
    {
        public global::System.Int32 id { get; set; }
        public global::System.Int32 user1_id { get; set; }
        public global::System.Int32 user2_id { get; set; }
        public user user { get; set; }
        public user user1 { get; set; }

    }
}
