using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationMVCTanisma.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Anasayfa()
        {
            return View();
        }
        public ActionResult Deneme()
        {
            //ViewBag nedir
            ViewBag.Ad = "Ali";
            //ViewBag ile ViewData birbirinin aynısıdır
            //Sadece yazımları farklı
            //Ekranda ViewBag Ad içinde Headkiller'ı göreceğiz
            //Ali'yi göremiyoruz çünkü 43. satırda ViewBag'in taşıdğı Ad değişken yenden set edilmiştir.

            //ViewData
            ViewData["Ad"] = "Headkiller";
            //TempData
            TempData["Adiniz"] = "Ali";

            return View();
        }
    }
}