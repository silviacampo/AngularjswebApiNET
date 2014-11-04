using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApiAgenda.Models
{
  
    public partial class aevent
    {
        public global::System.Int32 id { get; set; }
        public global::System.String title { get; set; }

        public global::System.String description { get; set; }

        public global::System.Int32 user_id { get; set; }

        public global::System.Int32 location_id { get; set; }

        public global::System.DateTime startTime { get; set; }

        public Nullable<global::System.DateTime> endTime { get; set; }

        public global::System.String url { get; set; }

        public user user { get; set; }

        public location location { get; set; }

        public List<comment> comments { get; set; }
        public void CopyFrom(aevent aevent)
        {
            title = aevent.title;
            description = aevent.description;
            user_id = aevent.user_id;
            location_id = aevent.location_id;
            startTime = aevent.startTime;
            endTime = aevent.endTime;
            url = aevent.url;
        }
    }

}
