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
            List<Supplier> supplier = db.Supplier.ToList();
            ViewBag.Supplier = new SelectList(supplier, "Id", "Name");

            List<Category> category = db.Category.ToList();
            ViewBag.Category = new SelectList(category, "Id", "CategoryName");

            return View();

        }
        [HttpPost]
        public ActionResult AddProduct(ProductViewModel model)
        {
            Product prod = new Product();
            prod.Name = model.Name;
            prod.Stock = model.Stock;
            prod.SupplierId = model.SupplierId;
            prod.CategoryId = model.CategoryId;

            db.Product.Add(prod);
            db.SaveChanges();
          
              return RedirectToAction("Index");
        }

        public ActionResult liste()
        {
            return View(db.Product.ToList());
        }

      
    }
}