using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NewOnlineNoticeBoard;
using NewOnlineNoticeBoard.Models;

namespace NewOnlineNoticeBoard.Controllers
{
    public class NewAdminsController : Controller
    {
        private NewONB db = new NewONB();

        // GET: NewAdmins
        public ActionResult Index()
        {
            return View(db.NewAdmins.ToList());
        }

        // GET: NewAdmins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewAdmin newAdmin = db.NewAdmins.Find(id);
            if (newAdmin == null)
            {
                return HttpNotFound();
            }
            return View(newAdmin);
        }

        // GET: NewAdmins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewAdmins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Username,Password,Department")] NewAdmin newAdmin)
        {
            if (ModelState.IsValid)
            {
                db.NewAdmins.Add(newAdmin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newAdmin);
        }

        // GET: NewAdmins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewAdmin newAdmin = db.NewAdmins.Find(id);
            if (newAdmin == null)
            {
                return HttpNotFound();
            }
            return View(newAdmin);
        }

        // POST: NewAdmins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Username,Password,Department")] NewAdmin newAdmin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newAdmin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newAdmin);
        }

        // GET: NewAdmins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewAdmin newAdmin = db.NewAdmins.Find(id);
            if (newAdmin == null)
            {
                return HttpNotFound();
            }
            return View(newAdmin);
        }

        // POST: NewAdmins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewAdmin newAdmin = db.NewAdmins.Find(id);
            db.NewAdmins.Remove(newAdmin);
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
