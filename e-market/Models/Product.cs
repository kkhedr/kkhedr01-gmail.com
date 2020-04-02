using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace e_market.Models
{
    public class Product
    {
        public int id { get; set; }
        public String name { get; set; }
        public double price { get; set; }
        public String image { get; set; }
        public String description { get; set; }
        public Category Category { get; set; }


        [ForeignKey("Category")]
        [DisplayName("Category")]
        public int Category_id { get; set; }
    }
}