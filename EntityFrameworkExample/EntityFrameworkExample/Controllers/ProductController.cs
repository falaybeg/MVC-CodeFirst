using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using EntityFrameworkExample.Models;

namespace EntityFrameworkExample.Controllers
{
    public class ProductController : Controller
    {
        eCommerceContext db = new eCommerceContext();
        // GET: Product
        public ActionResult Index()
        {
            return View();
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

            return RedirectToAction("ListProduct");
        }

        public ActionResult ListProduct()
        {
            db.Configuration.LazyLoadingEnabled = false;
            return View(db.Product.ToList());
        }
    }
}