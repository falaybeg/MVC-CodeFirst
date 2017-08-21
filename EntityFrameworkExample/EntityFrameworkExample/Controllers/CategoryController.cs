using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using EntityFrameworkExample.Models;

namespace EntityFrameworkExample.Controllers
{
    public class CategoryController : Controller
    {
        eCommerceContext db = new eCommerceContext();
        // GET: Category
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
        public ActionResult ListCategory()
        {
            var list = db.Category.ToList();
            return View(list);
        }

    }
}