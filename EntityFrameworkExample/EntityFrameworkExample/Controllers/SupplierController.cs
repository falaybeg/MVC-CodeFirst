using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using EntityFrameworkExample.Models;

namespace EntityFrameworkExample.Controllers
{
    public class SupplierController : Controller
    {
        eCommerceContext db = new eCommerceContext();
        // GET: Supplier
        [HttpGet]
        public ActionResult AddSupplier()
        {
            List<City> city = db.City.ToList();
            ViewBag.City = new SelectList(city, "Id", "Name");

            return View();
        }

        [HttpPost]
        public ActionResult AddSupplier(SupplierViewModel model)
        {
            Supplier supplier = new Supplier();
            supplier.Name = model.Name;
            supplier.Address = model.Address;
            supplier.Phone = model.Phone;
            supplier.CityId = model.CityId; 

            db.Supplier.Add(supplier);
            db.SaveChanges();
            return RedirectToAction("ListSupplier");
        }

        public ActionResult ListSupplier()
        {
            var list = db.Supplier.ToList();
            return View(list);
        }

        public ActionResult DeleteSupplier(int id)
        {
            Supplier delete = new Supplier();
            delete = db.Supplier.Find(id);
            db.Supplier.Remove(delete);
            db.SaveChanges();

            return RedirectToAction("ListSupplier");
        }
    }
}