using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abc.MvcWebUI.Entity;
using Abc.MvcWebUI.Identity;
using Abc.MvcWebUI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace Abc.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        private DataContext db = new DataContext();
        private UserManager<ApplicationUser> userManager;

        private RoleManager<ApplicationRole> roleManager;

        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            userManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            roleManager = new RoleManager<ApplicationRole>(roleStore);
        }

        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Email = model.Email;
                user.UserName = model.UserName;

                IdentityResult result = userManager.Create(user, model.Password);
                if (result.Succeeded)
                {
                    //User is create and use role
                    if (roleManager.RoleExists("user"))
                    {
                        userManager.AddToRole(user.Id, "user");
                    }

                    return RedirectToAction("Login", "Account");
                }
                else

                {
                    ModelState.AddModelError("RegisterUserError", "Something went wrong.Try Again");
                }



            }
            return View(model);
        }



        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.Find(model.UserName, model.Password);


                if (user != null)
                {
                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var indentityclaims = userManager.CreateIdentity(user, "ApplicationCookie");
                    var authproperties = new AuthenticationProperties();

                    authproperties.IsPersistent = model.RememberMe;
                    authManager.SignIn(authproperties, indentityclaims);

                    if (!String.IsNullOrEmpty(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }
                else

                {
                    ModelState.AddModelError("RegisterUserError", "User Not Found.Try Again");
                }

            }
            return View(model);
        }

        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult Index()
        {
            var username = User.Identity.Name;
            var orders = db.Orders
                .Where(i => i.Username == username)
                .Select(i => new UserOrderModel()
                {
                    Id=i.Id,
                    OrderNumber = i.OrderNumber,
                    OrderState = i.OrderState,
                    Total = i.Total,
                    OrderDate = i.OrderDate


                }).OrderByDescending(i=>i.OrderDate).ToList();




            return View(orders);
        }
        [Authorize]
        public ActionResult Details(int id)
        {
            var entity = db.Orders
                .Where(i => i.Id == id)
                .Select(i => new OrderDetailsModel()
                {
                    OrderId = i.Id,
                    OrderNumber = i.OrderNumber,
                    Total = i.Total,
                    OrderDate = i.OrderDate,
                    OrderState = i.OrderState,

                    AddressName = i.AddressName,
                    Address = i.Address,
                    City = i.City,
                    Neighborhood = i.Neighborhood,
                    PostCode = i.PostCode,
                    District = i.District,

                    OrderLines = i.OrderLines
                        .Select(a=>new OrderLineModel()
                        {
                            ProductId = a.ProductId,
                            ProductName = a.Product.Name.Length>50?a.Product.Name.Substring(0,47)+"..." : a.Product.Name,
                            Image = a.Product.Image,
                            Quantity = a.Quantity,
                            Price = a.Price

                        }).ToList()
                }).FirstOrDefault();


            return View(entity);
        }
    }
}