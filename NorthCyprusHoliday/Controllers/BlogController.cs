using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NorthCyprusHoliday.Models.Siniflar;
using PagedList;

namespace NorthCyprusHoliday.Controllers
{
    public class BlogController : Controller
    {
        Context c = new Context();
        BlogYorum by = new BlogYorum();
        public ActionResult Index(int page = 1)
        {

           by.Deger1 = c.Blogs.ToList();
            by.Deger3 = c.Blogs.Take(3).ToList();
            //var bloglar = c.Blogs.ToList().ToPagedList(page, 3);
            return View(by);
        }
        
        public ActionResult BlogDetay(int id)
        { 
            
           // var blogBul = c.Blogs.Where(x=>x.Id==id).ToList();
           by.Deger1=c.Blogs.Where(x=> x.Id == id).ToList();
            by.Deger2 = c.Yorumlars.Where(x=>x.BlogId == id).ToList();
            return View(by);
        }

        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }


            [HttpPost]
        public PartialViewResult YorumYap(Yorumlar yorumlar)
        {
            c.Yorumlars.Add(yorumlar);
            c.SaveChanges();
            return PartialView();
        }
      
    }

}