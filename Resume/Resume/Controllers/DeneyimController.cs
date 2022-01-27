using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Resume.Models.Entity;
using Resume.Repositories;
namespace Resume.Controllers
{
    public class DeneyimController : Controller
    {
        // GET: Deneyim
        DbResumeEntities db = new DbResumeEntities();
        DeneyimRepository repo = new DeneyimRepository();
        public ActionResult Index()
        {
            var deneyimler = repo.List();
            return View(deneyimler);
        }
        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeneyimEkle(tbldeneyimler p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeneyimSil(int id)
        {
            tbldeneyimler t = repo.Find(x => x.id == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            tbldeneyimler t = repo.Find(x => x.id == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult DeneyimGetir(tbldeneyimler p)
        {
            tbldeneyimler t = repo.Find(x => x.id == p.id);
            t.baslik = p.baslik;
            t.altbaslik = p.altbaslik;
            t.aciklama = p.aciklama;
            t.tarih = p.tarih;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
        
    }
}