using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Abc.MvcWebUI.Models
{
    public class ShippingDetails
    {
        
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please enter your address name")]
        public string AddressName { get; set; }

        [Required(ErrorMessage = "Please enter your address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter your City")]
        public string  City { get; set; }

        [Required(ErrorMessage = "Please enter your District")]
        public string District { get; set; }

        [Required(ErrorMessage = "Please enter your Neighborhood")]
        public string Neighborhood { get; set; }

        [Required(ErrorMessage = "Please enter your PostCode")]
        public string PostCode { get; set; }
    }
}