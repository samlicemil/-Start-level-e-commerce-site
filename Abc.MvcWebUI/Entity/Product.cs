using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Abc.MvcWebUI.Entity
{
    public class Product
    {
        public int Id { get; set; }
        [DisplayName("Product Name")]
        public string Name { get; set; }
        [DisplayName("Product Description")]
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }
        public bool isHome { get; set; }
        public bool IsApproved { get; set; }


        public int CategoryId { get; set; }
        public Category Category { get; set; }


    }
}