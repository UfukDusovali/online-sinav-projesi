using OrnekProje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrnekProje.Controllers
{
    public class UserController : Controller
    {
        private OrnekProjeEntities db = new OrnekProjeEntities();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User kullanici)
        {
            var KullaniciVarmi = db.User.Any(x => x.Mail == kullanici.Mail && x.Password == kullanici.Password);
            if (KullaniciVarmi!=false)
            {
                Session["Kullanici"] = kullanici.Mail;
                return RedirectToAction("Index","home");
            }
            else
            {
                ViewBag.Mesaj = "Böyle bir kullanıcı yok";
                return View();
            }
        }

      
    }
}
