using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Resume.Models.Entity;
using Resume.Repositories;
namespace Resume.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya

        GenericRepository<tblsosyalmedya> repo = new GenericRepository<tblsosyalmedya>();
        public ActionResult Index()
        {
            var sosyalmedya = repo.List();
            return View(sosyalmedya);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(tblsosyalmedya p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Getir(int id)
        {
            var hesap = repo.Find(x => x.id == id);
            return View(hesap);
        }
        [HttpPost]
        public ActionResult Getir(tblsosyalmedya p)
        {
            var hesap = repo.Find(x => x.id == p.id);
            hesap.ad = p.ad;
            hesap.durum = true;
            hesap.link = p.link;
            hesap.icon = p.icon;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var hesap = repo.Find(x => x.id == id);
            hesap.durum = false;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }
    }
}