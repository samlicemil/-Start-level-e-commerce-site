using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Abc.MvcWebUI.Entity
{
    public class Category
    {
        public int Id { get; set; }

        [DisplayName("Category Name")]
        [StringLength(50,MinimumLength = 1)]
        public string Name { get; set; }
        [StringLength(50, MinimumLength = 1)]
        [DisplayName("Category Description")]
        public string  Description { get; set; }

        
        public List<Product> Products { get; set; }
    }
}