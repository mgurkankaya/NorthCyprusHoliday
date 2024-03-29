using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NorthCyprusHoliday.Models.Siniflar;

namespace NorthCyprusHoliday.Controllers
{
    public class AdminController : Controller
    {
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniBlog(Blog blog)
        {
            c.Blogs.Add(blog);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogSil(int id)
        {
            var blog = c.Blogs.Find(id);
            c.Blogs.Remove(blog);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult BlogGetir(int id)
        {
            var bl = c.Blogs.Find(id);
           
            return View("BlogGetir",bl);
        }

        public ActionResult BlogGuncelle(Blog blog)
        {
            var blg = c.Blogs.Find(blog.Id);
            blg.Aciklama = blog.Aciklama;
            blg.Baslik = blog.Baslik;
            blg.BlogImage = blog.BlogImage;
            blg.Tarih = blog.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YorumListesi()
        {
            var yorumlar = c.Yorumlars.ToList();
            return View(yorumlar);
        }

        public ActionResult YorumSil(int id)
        {
            var value = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(value);
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }

        public ActionResult YorumGetir(int id)
        {
            var yr = c.Yorumlars.Find(id);

            return View("YorumGetir", yr);
        }

        public ActionResult YorumGuncelle(Yorumlar yorumlar)
        {
            var yrm = c.Yorumlars.Find(yorumlar.Id);
            yrm.KullaniciAdi = yorumlar.KullaniciAdi;
            yrm.Mail = yorumlar.Mail;
            yrm.Yorum = yorumlar.Yorum;

            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }

    }
}