using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class Food_DatabaseController : Controller
    {
        private Food_Model db = new Food_Model();

        // GET: Food_Database
        public ActionResult Index()
        {
            return View(db.Food_Database.ToList());
        }

        // GET: Food_Database/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food_Database food_Database = db.Food_Database.Find(id);
            if (food_Database == null)
            {
                return HttpNotFound();
            }
            return View(food_Database);
        }

        // GET: Food_Database/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Food_Database/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,Energy,Protein,Carbohydrate,Fat,Fiber")] Food_Database food_Database)
        {
            if (ModelState.IsValid)
            {
                db.Food_Database.Add(food_Database);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(food_Database);
        }

        // GET: Food_Database/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food_Database food_Database = db.Food_Database.Find(id);
            if (food_Database == null)
            {
                return HttpNotFound();
            }
            return View(food_Database);
        }

        // POST: Food_Database/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,Energy,Protein,Carbohydrate,Fat,Fiber")] Food_Database food_Database)
        {
            if (ModelState.IsValid)
            {
                db.Entry(food_Database).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(food_Database);
        }

        // GET: Food_Database/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food_Database food_Database = db.Food_Database.Find(id);
            if (food_Database == null)
            {
                return HttpNotFound();
            }
            return View(food_Database);
        }

        // POST: Food_Database/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Food_Database food_Database = db.Food_Database.Find(id);
            db.Food_Database.Remove(food_Database);
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
    }
}
