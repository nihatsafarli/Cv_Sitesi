using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Resume.Models.Entity;
using Resume.Repositories;
namespace Resume.Controllers
{
    public class HakkımdaController : Controller
    {
        // GET: Hakkımda
        DbResumeEntities db = new DbResumeEntities();
        GenericRepository<tblhakkimda> repo = new GenericRepository<tblhakkimda>();
        [HttpGet]
        public ActionResult Index()
        {
            var hakkimda = repo.List();
            return View(hakkimda);
        }
        [HttpPost]
        public ActionResult Index(tblhakkimda p)
        {
            var h = repo.Find(x => x.id ==1);
            h.ad = p.ad;
            h.soyad = p.soyad;
            h.adres = p.adres;
            h.telefon = p.telefon;
            h.mail = p.mail;
            h.aciklama = p.aciklama;
            h.resim = p.resim;
            repo.TUpdate(h);
            return RedirectToAction("Index");
        }
    }
}