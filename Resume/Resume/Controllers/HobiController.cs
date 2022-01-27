using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Resume.Models.Entity;
using Resume.Repositories;

namespace Resume.Controllers
{
    public class HobiController : Controller
    {
        // GET: Hobi
        DbResumeEntities db = new DbResumeEntities();
        GenericRepository<tblhobiler> repo = new GenericRepository<tblhobiler>();
        
        public ActionResult Index()
        {
            var hobiler = repo.List();
            return View(hobiler);
        }
        [HttpGet]
        public ActionResult HobiGetir(int id)
        {
            tblhobiler t = repo.Find(x => x.id == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult HobiGetir(tblhobiler p)
        {
            tblhobiler t = repo.Find(x => x.id == p.id);
            t.hobiler= p.hobiler;                     
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult HobiEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult HobiEkle(tblhobiler p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult HobiSil(int id)
        {
            var ser = repo.Find(x => x.id == id);
            repo.TDelete(ser);
            return RedirectToAction("Index");
        }

    }
}