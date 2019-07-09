using Abc.MvcWebUI.Entity;
using Abc.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Abc.MvcWebUI.Controllers
{
    public class HomeController : Controller
    {
        DataContext _context = new DataContext();
        // GET: Home
        public ActionResult Index()
        {
            var products = _context.Products
                .Where(i => i.isHome && i.IsApproved)
                .Select(i => new ProductModel()
                {
                    Id = i.Id,
                    Name = i.Name.Length>50 ?i.Name.Substring(0,50)+"...":i.Name,
                    Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                    Price = i.Price,
                    Image = i.Image ?? "default.jpeg",
                    CategoryId = i.CategoryId
                })

                .ToList();

            return View(products);
        }
        public ActionResult Details( int id)
        {
            return View(_context.Products.Where(i => i.Id==id).FirstOrDefault());
        }
        public ActionResult List(int? id)
        {
            if (id!=null)
            {
                var productsId=_context.Products
                    .Where(i=>i.IsApproved && i.CategoryId == id)
                    .Select(i => new ProductModel()
                    {
                        Id = i.Id,
                        Name = i.Name.Length > 50 ? i.Name.Substring(0, 50) + "..." : i.Name,
                        Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                        Price = i.Price,
                        Image = i.Image ?? "default.jpeg",
                        CategoryId = i.CategoryId
                    })

                    .ToList();

                return View(productsId);


            }

            var products = _context.Products
                .Where(i => i.IsApproved)
                .Select(i => new ProductModel()
                {
                    Id = i.Id,
                    Name = i.Name.Length > 50 ? i.Name.Substring(0, 50) + "..." : i.Name,
                    Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                    Price = i.Price,
                    Image = i.Image?? "default.jpeg" ,
                    CategoryId = i.CategoryId
                })

                .ToList();

            return View(products);
        }

        public PartialViewResult GetCategories()
        {
            return PartialView(_context.Categories.ToList());
        }
    }
}