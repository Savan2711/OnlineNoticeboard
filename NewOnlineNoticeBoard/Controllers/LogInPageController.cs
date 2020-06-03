using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using NewOnlineNoticeBoard.Models;
using System.Web.Mvc;
using System.IO;
using System.Runtime.CompilerServices;
using System.Web.Services.Description;

namespace NewOnlineNoticeBoard.Controllers
{
    public class LogInPageController : Controller
    {
        private NewONB db = new NewONB();
        // GET: LogInPage
        public ActionResult AdminLogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminLogIn(NewAdmin newAdmin)
        {
            var uname = newAdmin.Username;
            var passwd = newAdmin.Password;
            var que = db.NewAdmins.Where(s => s.Username == uname).FirstOrDefault();
            if (que != null)
            {
                if (que.Password == passwd)
                {
                    Session["DeptOfAdmin"] = que.Department;
                    return RedirectToAction("AdminCanSelect");
                }
                else
                {
                    ViewBag.pass = "Invalid Password";
                    return View();
                }
            }
            else
            {
                ViewBag.uname = "Invalid Username";
                return View();
            }
        }

        public ActionResult AdminCanSelect()
        {
            if (Session["DeptOfAdmin"] != null)
            {
                ViewBag.DeptOfAdmin = Session["DeptOfAdmin"];
                var temp = Session["DeptOfAdmin"].ToString();

                List<SelectListItem> Notices = null;
                var Item = (from s in db.TypeOfnotices
                            where s.Department == temp
                            select new SelectListItem
                            {
                                Text = s.NoticeType,
                                Value = s.NoticeType
                            }).Distinct();
                Notices = Item.ToList();
                ViewData["Notices"] = Notices;

                return View();
            }
            else
            {
                return RedirectToAction("AdminLogIn");
            }
        }

        public ActionResult DisplayNotice()
        {
            var dept = (string)Session["DeptOfAdmin"];
            ViewBag.dept = dept;
            if (dept == "CE")
            {
                return RedirectToAction("DisplayCeNotice");
            }
            else if (dept == "IT")
            {
                return RedirectToAction("DisplayItNotice");
            }
            else if (dept == "IC")
            {
                return RedirectToAction("DisplayIcNotice");
            }
            else if (dept == "EC")
            {
                return RedirectToAction("DisplayEcNotice");
            }
            else if (dept == "CH")
            {
                return RedirectToAction("DisplayChNotice");
            }
            else if (dept == "MH")
            {
                return RedirectToAction("DisplayMhNotice");
            }
            else
            {
                return RedirectToAction("AdminLogin");
            }
        
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DisplayNotice(HttpPostedFileBase file, FormCollection notice)
        {
            if (Request.Files.Count > 0)
            {
                if (file != null)
                {
                    var filename = Path.GetFileName(file.FileName);
                    file.SaveAs(Server.MapPath("~/uploads/" + filename));
                    var dept = (string)Session["DeptOfAdmin"];
                    ViewBag.dept = dept;
                    string title = notice["Title"];
                    DateTime dateofnotice = DateTime.Parse(notice["date"]);
                    string noticetype = Convert.ToString(notice["NoticeType"]);
                    if (dept == "CE")
                    {
                        CE_Notice record = new CE_Notice()
                        {
                            TitleOfNotice = title,
                            date = dateofnotice,
                            NoticeType = noticetype,
                            FileName = filename
                        };
                        db.CE_Notices.Add(record);
                        db.SaveChanges();


                        return RedirectToAction("DisplayCeNotice");

                    }
                    else if (dept == "IT")
                    {
                        IT_Notice record = new IT_Notice()
                        {
                            TitleOfNotice = title,
                            date = dateofnotice,
                            NoticeType = noticetype,
                            FileName = filename
                        };
                        db.IT_Notices.Add(record);
                        db.SaveChanges();
                        return RedirectToAction("DisplayItNotice");
                    }
                    else if (dept == "IC")
                    {
                        IC_Notice record = new IC_Notice()
                        {
                            TitleOfNotice = title,
                            date = dateofnotice,
                            NoticeType = noticetype,
                            FileName = filename
                        };
                        db.IC_Notices.Add(record);
                        db.SaveChanges();
                        return RedirectToAction("DisplayIcNotice");
                    }
                    else if (dept == "EC")
                    {
                        EC_Notice record = new EC_Notice()
                        {
                            TitleOfNotice = title,
                            date = dateofnotice,
                            NoticeType = noticetype,
                            FileName = filename
                        };
                        db.EC_Notices.Add(record);
                        db.SaveChanges();
                        return RedirectToAction("DisplayEcNotice");
                    }
                    else if (dept == "CH")
                    {
                        CH_Notice record = new CH_Notice()
                        {
                            TitleOfNotice = title,
                            date = dateofnotice,
                            NoticeType = noticetype,
                            FileName = filename
                        };
                        db.CH_Notices.Add(record);
                        db.SaveChanges();
                        return RedirectToAction("DisplayChNotice");
                    }
                    else if (dept == "MH")
                    {
                        MH_Notice record = new MH_Notice()
                        {
                            TitleOfNotice = title,
                            date = dateofnotice,
                            NoticeType = noticetype,
                            FileName = filename
                        };
                        db.MH_Notices.Add(record);
                        db.SaveChanges();
                        return RedirectToAction("DisplayMhNotice");
                    }
                    else
                    {

                    }
                    return View();
                }
                else
                {
                    ViewBag.msg = "File not uploaded successfully";
                    return View();
                }
                }
            return View();
        }

        public ActionResult DisplayCeNotice()
        {
            if (Session["DeptOfAdmin"] != null)
            {
                List<CE_Notice> CeNotices = new List<CE_Notice>();
                CeNotices = (List<CE_Notice>)db.CE_Notices.Select(s => s).ToList();
                return View(CeNotices);
            }
            else
            {
                return RedirectToAction("AdminLogIn");
            }
        }

        public ActionResult DisplayItNotice()
        {
            if (Session["DeptOfAdmin"] != null)
            {
                List<IT_Notice> ItNotices = new List<IT_Notice>();
                ItNotices = (List<IT_Notice>)db.IT_Notices.Select(s => s).ToList();
                return View(ItNotices);
            }
            else
            {
                return RedirectToAction("AdminLogIn");
            }
        }

        public ActionResult DisplayEcNotice()
        {
            if(Session["DeptOfAdmin"]!=null)
            { 
                List<EC_Notice> EcNotices = new List<EC_Notice>();
                EcNotices = (List<EC_Notice>)db.EC_Notices.Select(s => s).ToList();
                return View(EcNotices);
            }
            else
            {
                return RedirectToAction("AdminLogIn");
            }
        }

        public ActionResult DisplayIcNotice()
        {
            if(Session["DeptOfAdmin"]!=null)
            { 
                List<IC_Notice> IcNotices = new List<IC_Notice>();
                IcNotices = (List<IC_Notice>)db.IC_Notices.Select(s => s).ToList();
                return View(IcNotices);
            }
            else
            {
                return RedirectToAction("AdminLogIn");
            }
        }

        public ActionResult DisplayChNotice()
        {
            if(Session["DeptOfAdmin"]!=null)
            { 
                List<CH_Notice> ChNotices = new List<CH_Notice>();
                ChNotices = (List<CH_Notice>)db.CH_Notices.Select(s => s).ToList();
                return View(ChNotices);
            }
            else
            {
                return RedirectToAction("AdminLogIn");
            }
        }

        public ActionResult DisplayMhNotice()
        {
            if (Session["DeptOfAdmin"] != null)
            {
                List<MH_Notice> MhNotices = new List<MH_Notice>();
                MhNotices = (List<MH_Notice>)db.MH_Notices.Select(s => s).ToList();
                return View(MhNotices);
            }
            else
            {
                return RedirectToAction("AdminLogIn");
            }
        }


        //User Module

        public ActionResult UserLogIn()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserLogIn(FormCollection userdata)
        {
            var email = userdata["emailid"];
            var passwd = userdata["Password"];
            var user = db.Users.Where(s => s.EmailId == email).FirstOrDefault();
            if(user!=null)
            {
                if(user.Password == passwd)
                {
                    Session["emailid"] = email;
                    return Redirect("~/NoticeToUser/UserCanSelect");

                }
                else
                {
                    ViewBag.pass = "Invalid Password";
                    return View();
                }
            }
            else
            {
                ViewBag.useremail = "Invalid EmailId";
                return View();
            }
        }

        public ActionResult DeleteNotice()
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            if (Session["DeptOfAdmin"].ToString() == "CE")
            {
                CE_Notice notices = db.CE_Notices.Where(s => s.NoticeId == id).FirstOrDefault();
                db.CE_Notices.Remove(notices);
                db.SaveChanges();
                return Redirect("~/LogInPage/DisplayCeNotice");
            }
            else if (Session["DeptOfAdmin"].ToString() == "IT")
            {
                IT_Notice notices = db.IT_Notices.Where(s => s.NoticeId == id).FirstOrDefault();
                db.IT_Notices.Remove(notices);
                db.SaveChanges();
                return Redirect("~/LogInPage/DisplayItNotice");
            }
            else if (Session["DeptOfAdmin"].ToString() == "EC")
            {
                EC_Notice notices = db.EC_Notices.Where(s => s.NoticeId == id).FirstOrDefault();
                db.EC_Notices.Remove(notices);
                db.SaveChanges();
                return Redirect("~/LogInPage/DisplayEcNotice");
            }
            else if (Session["DeptOfAdmin"].ToString() == "MH")
            {
                MH_Notice notices = db.MH_Notices.Where(s => s.NoticeId == id).FirstOrDefault();
                db.MH_Notices.Remove(notices);
                db.SaveChanges();
                return Redirect("~/LogInPage/DisplayMhNotice");
            }
            else if (Session["DeptOfAdmin"].ToString() == "IC")
            {
                IC_Notice notices = db.IC_Notices.Where(s => s.NoticeId == id).FirstOrDefault();
                db.IC_Notices.Remove(notices);
                db.SaveChanges();
                return Redirect("~/LogInPage/DisplayIcNotice");
            }
            else if (Session["DeptOfAdmin"].ToString() == "CH")
            {
                CH_Notice notices = db.CH_Notices.Where(s => s.NoticeId == id).FirstOrDefault();
                db.CH_Notices.Remove(notices);
                db.SaveChanges();
                return Redirect("~/LogInPage/DisplayChNotice");
            }
            else
            {
                return Redirect("~/LogInPage/AdminLogIn");
            }
        }
    }
}