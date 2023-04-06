using System;
using System.Collections.Generic;

#nullable disable

namespace MyFinance.Webapi.Models.Domains
{
    public partial class Category
    {
        public Category()
        {
            Operations = new HashSet<Operations>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Operations> Operations { get; set; }
    }
}
