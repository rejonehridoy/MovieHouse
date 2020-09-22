using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicWeb.Models
{
    public class Cast
    {
        public string Cid { get; set; }
        public string Name { get; set; }
        public string RoleName { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string Age { get; set; }
        public Cast(string Cid,string Name,string RoleName)
        {
            this.Cid = Cid;
            this.Name = Name;
            this.RoleName = RoleName;
        }
    }
}