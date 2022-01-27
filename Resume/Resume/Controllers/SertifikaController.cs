using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Resume.Models.Entity;
using Resume.Repositories;
namespace Resume.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika
        GenericRepository<tblsertifikalar> repo = new GenericRepository<tblsertifikalar>();
        public ActionResult Index()
        {
            var sertifika = repo.List();
            return View(sertifika);
        }
        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            var sertifika = repo.Find(x => x.id == id);
            ViewBag.d = id;
            return View(sertifika);
        }
        [HttpPost]
        public ActionResult SertifikaGetir(tblsertifikalar s)
        {
            tblsertifikalar t = repo.Find(x => x.id == s.id);
            t.aciklama = s.aciklama;
            t.tarih = s.tarih;
            repo.TUpdate(s);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SertifikaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SertifikaEkle(tblsertifikalar p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
       public ActionResult SertifikaSil(int id)
        {
            var ser = repo.Find(x => x.id == id);
            repo.TDelete(ser);
            return RedirectToAction("Index");
        }
    }
}