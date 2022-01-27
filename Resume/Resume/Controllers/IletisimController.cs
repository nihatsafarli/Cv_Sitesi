using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Resume.Models.Entity;
using Resume.Repositories;
namespace Resume.Controllers
{
    public class IletisimController : Controller
    {
        // GET: Iletisim
        DbResumeEntities db = new DbResumeEntities();
        GenericRepository<tbliletisim> repo = new GenericRepository<tbliletisim>();
        public ActionResult Index()
        {
            var mesajlar = repo.List();
            return View(mesajlar);
        }
    }
}