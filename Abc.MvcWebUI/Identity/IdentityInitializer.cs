using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Abc.MvcWebUI.Identity
{
    public class IdentityInitializer :CreateDatabaseIfNotExists<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {

            if (!context.Roles.Any(i=>i.Name=="admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "admin", Description = "admin Role" };
                manager.Create(role);
            }

            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole(){Name = "user", Description = "user Role" };
                manager.Create(role);
            }

            if (!context.Users.Any(i=>i.Name=="cemilsamli"))
            {
                var store=new UserStore<ApplicationUser>(context);
                var manager=new UserManager<ApplicationUser>(store);
                var user=new ApplicationUser(){Name = "Cemil",Surname = "Samli",UserName= "samlicemil",Email = "samlicemil.m@gmail.com"};
                manager.Create(user, "147895263");

                manager.AddToRole(user.Id, "admin");
                
            }

            if (!context.Users.Any(i => i.Name == "Mali"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "mali", Surname = "sarigul", UserName = "usersamlicemil", Email = "mali.m@gmail.com" };
                manager.Create(user, "147895263");

                manager.AddToRole(user.Id, "user");
            }

            base.Seed(context);

        }
    }
}