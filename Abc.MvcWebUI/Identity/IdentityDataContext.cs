using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Abc.MvcWebUI.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Abc.MvcWebUI.Identity
{
    public class IdentityDataContext:IdentityDbContext<ApplicationUser>
    {
        public IdentityDataContext():base("dataConnection")
        {
           
        }
    }
}