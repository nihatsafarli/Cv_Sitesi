using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Resume.Models.Entity;
using Resume.Repositories;

namespace Resume.Controllers
{
    
    public class AdminController : Controller
    {  
        // GET: Admin
        DbResumeEntities db = new DbResumeEntities();
        GenericRepository<tbladmin> repo = new GenericRepository<tbladmin>();
        public ActionResult Index()
        {
            var liste = repo.List();
            return View(liste);
        }
        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminEkle(tbladmin p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult AdminSil(int id)
        {
            tbladmin t = repo.Find(x => x.id == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AdminGetir(int id)
        {
            tbladmin t = repo.Find(x => x.id == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult AdminGetir(tbladmin p)
        {
            tbladmin t = repo.Find(x => x.id == p.id);
            t.kullaniciadi = p.kullaniciadi;           
            t.sifre = p.sifre;           
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}