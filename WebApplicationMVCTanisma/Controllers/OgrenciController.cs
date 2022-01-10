using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationMVCTanisma.Models;

namespace WebApplicationMVCTanisma.Controllers
{
    public class OgrenciController : Controller
    {
        // GET: Ogrenci
        public ActionResult Listele()
        {
         List<Ogrenci> ogrList = Ogrenci.OgrencileriGetir();
            return View(ogrList);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Ogrenci ogr)
        {
            //Veritabanımız olmadığı için  id'yi kendi atama amaçlı bu satırları yazdık
            var tumOgrler = Ogrenci.OgrencileriGetir();
            ogr.Id = tumOgrler.Count + 1;

            //Öğrenciyi ekleyelim
            Ogrenci.OgrenciListesi.Add(ogr);

            //Ekleme yapıldıktan sonra Listele Action'ına redirect olalım.

            return RedirectToAction("Listele");
        }

        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            //Gelen id sıfırdan büyükse benim listemde onu bul ve View' e gönder.
            if (id>0)
            {
             Ogrenci bulunanOgr = Ogrenci.OgrenciListesi.FirstOrDefault(x => x.Id == id);
                return View(bulunanOgr);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Guncelle(Ogrenci yeniogr)
        {
            Ogrenci guncellenecekEskiOgr = Ogrenci.OgrenciListesi.FirstOrDefault(x => x.Id == yeniogr.Id);
            if (guncellenecekEskiOgr!=null)
            {
                //Öğrenciyi buldun. Bulduğun bu öğrenciye yeni değerlerini ata
                guncellenecekEskiOgr.Ad = yeniogr.Ad;
                guncellenecekEskiOgr.Soyad = yeniogr.Soyad;
                guncellenecekEskiOgr.DogumTarihi = yeniogr.DogumTarihi;
            }

            return RedirectToAction("Listele");
        }
    }
}