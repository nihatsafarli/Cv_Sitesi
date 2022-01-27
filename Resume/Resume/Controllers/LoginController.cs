using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Resume.Models.Entity;
using Resume.Repositories;

namespace Resume.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        GenericRepository<tbladmin> repo = new GenericRepository<tbladmin>();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(tbladmin p)
        {
            DbResumeEntities db = new DbResumeEntities();
            var bilgi = db.tbladmin.FirstOrDefault(x => x.kullaniciadi == p.kullaniciadi && x.sifre == p.sifre);
            if (bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.kullaniciadi, false);
                Session["kullaniciadi"] = bilgi.kullaniciadi.ToString();
                return RedirectToAction("Index","Hakkımda");
            }
            else
            {

                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}