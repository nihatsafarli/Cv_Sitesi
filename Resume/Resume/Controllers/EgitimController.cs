using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Resume.Models.Entity;
using Resume.Repositories;

namespace Resume.Controllers
{
    [Authorize]
    public class EgitimController : Controller
    {
        // GET: Egitim
        GenericRepository<tblegitimler> repo = new GenericRepository<tblegitimler>();

        public ActionResult Index()
        {
            var egitim = repo.List();
            return View(egitim);
        }
        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EgitimEkle(tblegitimler p) 
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult EgitimSil(int id)
        {
            tblegitimler e = repo.Find(x => x.id == id);
            repo.TDelete(e);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EgitimGetir(int id)
        {
            tblegitimler e = repo.Find(x => x.id == id);
            return View(e);
        }
        [HttpPost]
        public ActionResult EgitimGetir(tblegitimler p)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimGetir");
            }
            tblegitimler t = repo.Find(x => x.id == p.id);
            t.baslik = p.baslik;
            t.altbaslik1 = p.altbaslik1;
            t.altbaslik2 = p.altbaslik2;
            t.gno = p.gno;           
            t.tarih = p.tarih;
            repo.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}