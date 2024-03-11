using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class EgitimController : Controller
    {
        // GET: Egitim
        GenericRepository<TblEgitimlerim> repo = new GenericRepository<TblEgitimlerim>();
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
        public ActionResult EgitimEkle(TblEgitimlerim p)
        {
            repo.TAdd(p);
            if(!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            return RedirectToAction("Index");
        }
        public ActionResult EgitimSil(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            repo.TDelete(egitim);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EgitimGetir(int id)
        {
            var egitim=repo.Find(x=> x.ID == id);
            return View(egitim);
        }
        [HttpPost]
        public ActionResult EgitimGetir(TblEgitimlerim t)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimGetir");
            }
            var egitim = repo.Find(x => x.ID == t.ID);
            egitim.Title = t.Title;
            egitim.Subtitle1 = t.Subtitle1;
            egitim.GNO=t.GNO;
            egitim.Date = t.Date;
            repo.TUpdate(egitim);
            return RedirectToAction("Index");
        }

    }
}