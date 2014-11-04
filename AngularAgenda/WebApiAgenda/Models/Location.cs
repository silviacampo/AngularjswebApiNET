using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace WebApiAgenda.Models
{
   
   public partial class location
    {
        public global::System.Int32 id { get; set; }

        public global::System.String city { get; set; }

        public global::System.String country { get; set; }

        public global::System.Int32 timezone { get; set; }

        public List<aevent> aevents { get; set; }

        public void CopyFrom(location location)
        {
            city = location.city;
            country = location.country;
            timezone = location.timezone;
         }
    }



}
