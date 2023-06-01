using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models
{
    public partial class Realestate
    {
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public long SellerId { get; set; }
        public string? Description { get; set; }
        public DateOnly CreateAt { get; set; }
        public bool Freeofcharge { get; set; }
        public string ImageUrl { get; set; } = null!;
        public int? Area { get; set; }
        public int? Rooms { get; set; }
        public int? Floors { get; set; }
        public string? Latlong { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual Seller Seller { get; set; } = null!;
    }
}
