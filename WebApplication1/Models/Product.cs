using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    [Table("tblProducts")]
    public class Product
    {
        [Key]
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public string CompanyName { get; set; }
        public string OwnerName { get; set; }
        public string OwnerSurname { get; set; }
        public string Country { get; set; }
        public string City { get; set; }     

    }
}