using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ProductModel
    {
        public string ProductName { get; set; }
        public string Color { get; set; }
        public float Price { get; set; }
        public string CompanyName { get; set; }
        public string OwnerName { get; set; }
        public string OwnerSurname { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}