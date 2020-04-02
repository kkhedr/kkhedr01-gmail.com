using e_market.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e_market.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Product
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.products = db.product.ToList();
            ViewBag.categories = db.category.ToList();
            Product product = new Product();
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IndexFilter(Product product)
        {
            IEnumerable<Product> productss = new List<Product>();

            productss = db.product.ToList().Where(m => m.Category_id == product.Category_id);
            if (productss != null)
            {
                   
                ViewBag.categories = db.category.ToList();
                ViewBag.products = productss;
                
                return View("Index", product);
            }
            
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            ViewBag.Categories = db.category.ToList();
            return View();
        }

        public ActionResult show(int id)
        {
            var product = db.product.Include("Category").SingleOrDefault(m=>m.id == id);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult store(Product product)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = db.category.ToList();
                return View("Create");
            }
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                var _path = "";
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    _path = Path.Combine(
                        Server.MapPath("~/Content/uploads"), fileName);
                    file.SaveAs(_path);
                    product.image = fileName;
                    db.product.Add(product);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            ViewBag.Categories = db.category.ToList();
            return RedirectToAction("Create");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            ViewBag.Categories = db.category.ToList();
            var product = db.product.Find(id);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Product product)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = db.category.ToList();
                var prod = db.product.Find(product.id);
                return View("Update",prod);
            }
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                var _path = "";
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    _path = Path.Combine(
                        Server.MapPath("~/Content/uploads"), fileName);
                    file.SaveAs(_path);
                    product.image = fileName;
                    var product_details = db.product.Find(product.id);
                    product_details.name = product.name;
                    product_details.price = product.price;
                    product_details.image = product.image;
                    product_details.description = product.description;
                    product_details.Category_id = product.Category_id;
                   
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    var product_details = db.product.Find(product.id);
                    product_details.name = product.name;
                    product_details.price = product.price;
                    product_details.description = product.description;
                    product_details.Category_id = product.Category_id;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            
            ViewBag.Categories = db.category.ToList();
            var prodd = db.product.Find(product.id);
            return View("Update", prodd);

        }

        public ActionResult Delete(Product product)
        {
            var productt = db.product.Find(product.id);
            if (productt != null)
            {
                db.product.Remove(productt);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}