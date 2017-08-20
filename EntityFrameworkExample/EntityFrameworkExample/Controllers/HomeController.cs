using EntityFrameworkExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityFrameworkExample.Controllers
{
    public class HomeController : Controller
    {
        eCommerceContext db = new eCommerceContext();

        public ActionResult Index()
        {

            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            
                db.Category.Add(category);
                db.SaveChanges();
            
                return View();
        }
        [HttpGet]
        public ActionResult ShowCategory()
        {
            var list = db.Category.ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            var supplier = db.Supplier.ToList().Select(c => new SelectListItem
            {
                Selected = false,
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToList();
            ViewBag.Supplier = supplier;

            var category = db.Category.ToList().Select(c => new SelectListItem
            {
                Selected = false,
                Text = c.CategoryName,
                Value = c.Id.ToString()
            }).ToList();
            ViewBag.Category = category;

           

            //ViewBag.Category = new SelectList(db.Category, "Id", "CategoryName");
            //ViewBag.Supplier = new SelectList(db.Supplier, "Id", "Name");


            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product pro)
        {

            db.Product.Add(pro);
            db.SaveChanges();
            return View();
        }
    }
}