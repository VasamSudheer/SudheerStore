using SudheerStore.DAL;
using SudheerStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SudheerStore.Controllers
{
    public class StoreFrontController : Controller
    {
        private SudheerStoreEntities db = new SudheerStoreEntities();
        // GET: StoreFront
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
    }
}