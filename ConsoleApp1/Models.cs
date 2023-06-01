using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    public class Ad
    {
        public int Area { get; set; }
        public Category Category { get; set; }
        public DateTime CreateAt { get; set; }
        public string Description { get; set; }
        public int Floors { get; set; }
        public bool FreeOfCharge { get; set; }
        [Key]
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string LatLong { get; set; }
        public int Rooms { get; set; }
        public Seller Seller { get; set; }
        // id;rooms;latlong;floors;area;description;freeOfCharge;imageUrl;createAt;sellerId;sellerName;sellerPhone;categoryId;categoryName
        public Ad(string row)
        {
            var splittedData = row.Split(';');
            Id = int.Parse(splittedData[0]);
            Rooms = int.Parse(splittedData[1]);
            LatLong = splittedData[2];
            Floors = int.Parse(splittedData[3]);
            Area = int.Parse(splittedData[4]);
            Description = splittedData[5];
            switch (splittedData[6])
            {
                case "0":
                    FreeOfCharge = false;
                    break;
                case "1":
                    FreeOfCharge = true;
                    break;
                default: break;
            }
            ImageUrl = splittedData[7];
            CreateAt = DateTime.Parse(splittedData[8]);
            Seller = new Seller
            {
                Id = int.Parse(splittedData[9]),
                Name = splittedData[10],
                Phone = splittedData[11]
            };
            Category = new Category
            {
                Id = int.Parse(splittedData[12]),
                Name = splittedData[13]
            };
        }
        public Ad()
        {
            
        }
    }
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Seller
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
    
}
