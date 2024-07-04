using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WEBAPI.Models
{
    
    public class Product
    {
        public Nullable<int> ProductID { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Description { get; set; }
    }
    public class ProductApiResponse
    {
        public List<Product> Table { get; set; }
    }
}