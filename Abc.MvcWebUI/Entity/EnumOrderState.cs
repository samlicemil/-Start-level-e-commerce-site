using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Abc.MvcWebUI.Entity
{
    public enum EnumOrderState
    {
        [Display(Name = "Awaiting approval")]
        Waiting,
        [Display(Name = "Delivered to cargo")]
        Shipped,
        [Display(Name = "Delivery completed")]
        Complated
    }
}