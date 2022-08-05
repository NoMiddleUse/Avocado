using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using Microsoft.AspNet.Identity;
namespace WebApplication1.Controllers
{
    public class RecordsController : Controller
    {
        private Record_Model db = new Record_Model();

        // GET: Records
        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var records = db.Records.Where(r => r.UserId == userId).ToList();
            return View(records);
        }

        // GET: Records/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Records records = db.Records.Find(id);
            if (records == null)
            {
                return HttpNotFound();
            }
            return View(records);
        }

        // GET: Records/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Records/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,Weight,Height,Waist")] Records records)
        {
            records.UserId = User.Identity.GetUserId();
            records.Date = DateTime.Now;

            ModelState.Clear();
            TryValidateModel(records);
            if (ModelState.IsValid)
            {
                db.Records.Add(records);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(records);
        }

        // GET: Records/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Records records = db.Records.Find(id);
            if (records == null)
            {
                return HttpNotFound();
            }
            return View(records);
        }

        // POST: Records/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Weight,Height,Waist,UserId,Date")] Records records)
        {
            if (ModelState.IsValid)
            {
                db.Entry(records).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(records);
        }

        // GET: Records/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Records records = db.Records.Find(id);
            if (records == null)
            {
                return HttpNotFound();
            }
            return View(records);
        }

        // POST: Records/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Records records = db.Records.Find(id);
            db.Records.Remove(records);
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
