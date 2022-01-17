using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WPay.Utils;

namespace WPay.Controllers
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

        [HttpPost]
        public ActionResult generate_hash(string textToEncrypt, string merchant_hash)
        {
            textToEncrypt = new AES_128_ECB_Manager().Encrypt(textToEncrypt, merchant_hash);
            return Json(new { Success = true, Data = new { Code = 0, Message = textToEncrypt } }, JsonRequestBehavior.AllowGet);

        }
    }
}