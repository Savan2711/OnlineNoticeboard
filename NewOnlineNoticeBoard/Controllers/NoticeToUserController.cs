using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewOnlineNoticeBoard.Models;
using System.Web.Mvc;
using System.IO;
using System.Web.Hosting;

namespace NewOnlineNoticeBoard.Controllers
{
    public class NoticeToUserController : Controller
    {
        private NewONB db = new NewONB();
        // GET: NoticeToUser
        public ActionResult UserCanSelect(string err)
        {
            ViewBag.err = err;
            if (Session["emailid"] != null)
            {
                ViewData["cen"] = db.CE_Notices.Select(s => s);
                ViewData["itn"] = db.IT_Notices.Select(s => s);
                ViewData["ecn"] = db.EC_Notices.Select(s => s);
                ViewData["chn"] = db.CH_Notices.Select(s => s);
                ViewData["icn"] = db.IC_Notices.Select(s => s);
                ViewData["mhn"] = db.MH_Notices.Select(s => s);
                return View();
            }
            else
            {
                return Redirect("~/LogInPage/UserLogIn");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DisplayFileNotice(FormCollection NoticeData)
        {
            var dept = NoticeData["Dept"];
            DateTime date = DateTime.Parse(NoticeData["Date"]);
            if(dept == "CE")
            {
                List<CE_Notice> Notices = db.CE_Notices.Where(s=>s.date==date).ToList();
                if (Notices.Count >0)
                {
                    TempData["Notices"] = Notices;
                    return Redirect(Url.Action("DisplayFileCeNotice","NoticeToUser"));
                }
                else
                { return Redirect("~/NoticeToUser/UserCanSelect?err=Notice Not Found"); }
            }
            else if(dept == "IT")
            {
                List<IT_Notice> Notices = db.IT_Notices.Where(s => s.date == date).ToList();
                if(Notices.Count>0)
                { TempData["Notices"] = Notices; return RedirectToAction("DisplayFileItNotice"); }
                else
                { return Redirect("~/NoticeToUser/UserCanSelect?err=Notice Not Found"); }
            }
            else if (dept == "EC")
            {
                List<EC_Notice> Notices = db.EC_Notices.Where(s => s.date == date).ToList();
                if (Notices.Count > 0)
                { TempData["Notices"] = Notices; return RedirectToAction("DisplayFileEcNotice"); }
                else
                { return Redirect("~/NoticeToUser/UserCanSelect?err=Notice Not Found"); }
            }
            else if (dept == "CH")
            {
                List<CH_Notice> Notices = db.CH_Notices.Where(s => s.date == date).ToList();
                if (Notices.Count > 0)
                { TempData["Notices"] = Notices; return RedirectToAction("DisplayFileChNotice"); }
                else
                { return Redirect("~/NoticeToUser/UserCanSelect?err=Notice Not Found"); }
            }
            else if (dept == "IC")
            {
                List<IC_Notice> Notices = db.IC_Notices.Where(s => s.date == date).ToList();
                if (Notices.Count > 0)
                { TempData["Notices"] = Notices; return RedirectToAction("DisplayFileIcNotice"); }
                else
                { return Redirect("~/NoticeToUser/UserCanSelect?err=Notice Not Found"); }
            }
            else if (dept == "MH")
            {
                List<MH_Notice> Notices = db.MH_Notices.Where(s => s.date == date).ToList();
                if (Notices.Count > 0)
                { TempData["Notices"] = Notices; return RedirectToAction("DisplayFileMhNotice"); }
                else
                { return Redirect("~/NoticeToUser/UserCanSelect?err=Notice Not Found"); }
            }
            return View();
        }

        public ActionResult DisplayFileCeNotice()
        {
            if (Session["emailid"] != null)
            {
                return View(TempData["Notices"]);
            }
            else
            {
                return Redirect("~/LogInPage/UserLogIn");
            }
        }
        public ActionResult DisplayFileItNotice()
        {
            if (Session["emailid"] != null)
            {
                return View(TempData["Notices"]);
            }
            else
            {
                return Redirect("~/LogInPage/UserLogIn");
            }
        }
        public ActionResult DisplayFileEcNotice()
        {
            if (Session["emailid"] != null)
            {
                return View(TempData["Notices"]);
            }
            else
            {
                return Redirect("~/LogInPage/UserLogIn");
            }
        }
        public ActionResult DisplayFileChNotice()
        {
            if (Session["emailid"] != null)
            {
                return View(TempData["Notices"]);
            }
            else
            {
                return Redirect("~/LogInPage/UserLogIn");
            }
        }
        public ActionResult DisplayFileIcNotice()
        {
            if (Session["emailid"] != null)
            {
                return View(TempData["Notices"]);
            }
            else
            {
                return Redirect("~/LogInPage/UserLogIn");
            }
        }
        public ActionResult DisplayFileMhNotice()
        {
            if (Session["emailid"] != null)
            {
                return View(TempData["Notices"]);
            }
            else
            {
                return Redirect("~/LogInPage/UserLogIn");
            }
        }

        public ActionResult Download(string file)
        {
            file = HostingEnvironment.MapPath("~/uploads/"+file);
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            var filename = Path.GetFileName(file);
            return File(file,contentType,filename);
        }
    }
}