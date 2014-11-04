using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebApiAgenda.Models
{
    public partial class user
    {
        public global::System.Int32 id { get; set; }

        public global::System.String username { get; set; }

        public global::System.String password { get; set; }

        public global::System.String email { get; set; }

        public List<friend> friends { get; set; }
        public List<aevent> aevents { get; set; }
        public List<comment> comments { get; set; }
        public List<friend> friends1 { get; set; }

        public bool isAdmin { get; set; }

 
    }

}
