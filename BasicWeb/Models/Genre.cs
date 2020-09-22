using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicWeb.Models
{
    public class Genre
    {
        public string Gid { get; set; }
        public string Name { get; set; }
        public string MovieCount { get; set; }
        public Genre(string Gid,string Name,string MovieCount)
        {
            this.Gid = Gid;
            this.Name = Name;
            this.MovieCount = MovieCount;
        }
    }
}