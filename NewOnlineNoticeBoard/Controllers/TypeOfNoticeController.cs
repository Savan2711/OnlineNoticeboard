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
    public class TypeOfNoticeController : Controller
    {
        private NewONB db = new NewONB();

        // GET: TypeOfNotice/Create
        public ActionResult Create()
        {
            ViewBag.DeptOfAdmin = Request.QueryString["DeptOfAdmin"].ToString();
            return View();
        }

        // POST: TypeOfNotice/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TypeOfNotice typeOfNotice)
        {
            if (ModelState.IsValid)
            {
                var type = typeOfNotice.NoticeType.ToString();
                var dept = typeOfNotice.Department.ToString();
                TypeOfNotice notice = new TypeOfNotice() { NoticeType = type , Department = dept};
                db.TypeOfnotices.Add(notice);
                db.SaveChanges();
                return Redirect("~/LogInPage/AdminCanSelect");
            }

            return View(typeOfNotice);
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
