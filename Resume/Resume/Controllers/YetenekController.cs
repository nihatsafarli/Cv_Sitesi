using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Resume.Models.Entity;
using Resume.Repositories;
namespace Resume.Controllers
{
    public class YetenekController : Controller
    {
        // GET: Yetenek
        
        GenericRepository<tblyetenekler> repo = new GenericRepository<tblyetenekler>();
        public ActionResult Index()
        {
            var yetenekler = repo.List();
            return View(yetenekler);
        }
        [HttpGet]
        public ActionResult YetenekEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YetenekEkle(tblyetenekler p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult YetenekSil(int id)
        {
            tblyetenekler t = repo.Find(x => x.id == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YetenekGetir(int id)
        {
            tblyetenekler t = repo.Find(x => x.id == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult YetenekGetir(tblyetenekler p)
        {
           tblyetenekler t = repo.Find(x => x.id == p.id);
            t.yetenek = p.yetenek;
            t.oran = p.oran;         
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }

    }
}