using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicWeb.Models
{
    public class Category
    {
        public string CategoryName  { get; set; }
        public string Count { get; set; }
        public Category(string CategoryName,string Count)
        {
            this.CategoryName = CategoryName;
            this.Count = Count;
        }
    }
}