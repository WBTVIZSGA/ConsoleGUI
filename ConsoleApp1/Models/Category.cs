using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models
{
    public partial class Category
    {
        public Category()
        {
            Realestates = new HashSet<Realestate>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Realestate> Realestates { get; set; }
    }
}
