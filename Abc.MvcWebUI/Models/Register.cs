using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace Abc.MvcWebUI.Models
{
    public class Register
    {
        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }


        [Required]
        [DisplayName("Surname")]
        public string Surname { get; set; }

        [Required]
        [DisplayName("User Name")]
        public string UserName { get; set; }


        [Required]
        [DisplayName("Email")]
        [EmailAddress(ErrorMessage = "Please enter your email properly.")]
        public string Email { get; set; }


        [Required]
        [DisplayName("Password")]
        public string Password { get; set; }


        [Required]
        [DisplayName("RePassword")]
        [Compare("Password",ErrorMessage = "Your Passwords Do Not Match")]
        public string RePassword { get; set; }

    }
}