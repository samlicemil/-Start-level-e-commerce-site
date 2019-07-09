using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abc.MvcWebUI.Entity;
using Abc.MvcWebUI.Models;

namespace Abc.MvcWebUI.Controllers
{
    public class CartController : Controller
    {
        private DataContext db = new DataContext();
        // GET: Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }
        public ActionResult AddToCart(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id);
            if (product != null)
            {
                GetCart().AddProduct(product, 1);
            }



            return RedirectToAction("Index");
        }
        public ActionResult RemoveFromCart(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id);
            if (product != null)
            {
                GetCart().DeleteProduct(product);
            }



            return RedirectToAction("Index");
        }

        public Cart GetCart()
        {
            var cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }

            return cart;
        }

        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }
        public ActionResult Checkout()
        {
            return View(GetCart());
        }
        public ActionResult cclear()
        {
            GetCart().Clear();
            return RedirectToAction("Index");
        }
        public ActionResult Checkoutt()
        {
            return View(new ShippingDetails());
        }

        [Authorize]
        [HttpPost]
        public ActionResult Checkoutt(ShippingDetails entity)
        {
            var cart = GetCart();
            if (cart.CartLines.Count == 0)
            {
                ModelState.AddModelError("", "Your Basket is empty");
                return View(entity);
            }
            else
            {


                if (ModelState.IsValid)
                {
                    //database registration

                    SaveOrder(cart, entity);

                    cart.Clear();
                    return View("Complated");
                }
                else
                {
                    return View(entity);
                }
            }
        }

        private void SaveOrder(Cart cart, ShippingDetails entity)
        {
            var order=new Order();
            order.OrderNumber ="Order"+ (new Random()).Next(1111111, 99999999).ToString();
            order.Total = cart.Total();
            order.OrderDate=DateTime.Now;
            order.OrderState = EnumOrderState.Waiting;
            order.Username = User.Identity.Name;


            
            order.AddressName = entity.AddressName;
            order.Address = entity.Address;
            order.City = entity.City;
            order.PostCode = entity.PostCode;
            order.District = entity.District;
            order.Neighborhood = entity.Neighborhood;

            order.OrderLines=new List<OrderLine>();

            foreach (var item in cart.CartLines)
            {
                var orderline=new OrderLine();
                orderline.Quantity = item.Quantity;
                orderline.Price = item.Quantity * item.Product.Price;
                orderline.ProductId = item.Product.Id;

                order.OrderLines.Add(orderline);
            }

            db.Orders.Add(order);
            db.SaveChanges();
        }
    }
}