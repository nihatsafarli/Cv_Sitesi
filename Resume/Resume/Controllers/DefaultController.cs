using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Resume.Models.Entity;

namespace Resume.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DbResumeEntities db = new DbResumeEntities();
        public ActionResult Index()
        {
            var degerler = db.tblhakkimda.ToList();
            return View(degerler);
        }
        public PartialViewResult SosyalMedya()
        {
            var sosyalmedya = db.tblsosyalmedya.Where(x=>x.durum==true).ToList();
            return PartialView(sosyalmedya);
        }
        public PartialViewResult Deneyim()
        {
            var deneyimler = db.tbldeneyimler.ToList();
            return PartialView(deneyimler);
        }
        public PartialViewResult Egitim()
        {
            var egitimler = db.tblegitimler.ToList();
            return PartialView(egitimler);
        }
        public PartialViewResult Yetenek()
        {
            var yetenekler = db.tblyetenekler.ToList();
            return PartialView(yetenekler);
        }
        public PartialViewResult Hobi()
        {
            var hobiler = db.tblhobiler.ToList();
            return PartialView(hobiler);
        }
        public PartialViewResult Sertifika()
        {
            var sertifikalar = db.tblsertifikalar.ToList();
            return PartialView(sertifikalar);
        }
        [HttpGet]
        public PartialViewResult Iletisim()
        {
            
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Iletisim(tbliletisim t)
        {
            t.tarih =DateTime.Parse( DateTime.Now.ToShortDateString());
            db.tbliletisim.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}