using SudheerStore.CustomFilters;
using SudheerStore.DAL;
using SudheerStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SudheerStore.Controllers
{
    [CustomAuthenticationFilter]
    public class ProductsController : Controller
    {
        private SudheerStoreEntities db = new SudheerStoreEntities();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price,Description,CreatedAt,CategoryId,Product_Image,BrandId,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count>0 && Request.Files[0].ContentLength>0)
                {
                    var file = Request.Files[0];
                    var content = new byte[file.ContentLength];
                    file.InputStream.Read(content, 0, file.ContentLength);
                    product.Product_Image = content;
                    db.Products.Add(product);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
               
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            ViewBag.BrandId = new SelectList(db.Brands, "brand_Id", "BrandName", product.BrandId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,Description,CreatedAt,CategoryId,BrandId,Stock,Product_Image")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            ViewBag.BrandId = new SelectList(db.Brands, "brand_Id", "BrandName", product.BrandId);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public JsonResult GetBrands(string id)
        {
            var brandId = int.Parse(id);
            var Brands = db.Brands.Where(b=>b.CategoryId== brandId).ToList();

            List<SelectListItem> lstBrands = new List<SelectListItem>();
            lstBrands.Add(new SelectListItem { Text = "---Select Brands", Value = "0" });
            if(Brands!=null)
            {
                foreach (var x in Brands)
                {
                    lstBrands.Add(new SelectListItem { Text = x.BrandName, Value = x.brand_Id.ToString() });
                }
            }
            return Json(new SelectList(lstBrands, "Value", "Text", JsonRequestBehavior.AllowGet));
        }
    }
}