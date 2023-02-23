using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LuxHom.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Inicio";

            return View();
        }

        [HttpPost]
        public ActionResult Login(string user,string password)
        {
            // Aquí cualquier uso de las variables 'usr', 'pwd' y 'rme'
            ViewBag.User = user.ToString();
            ViewBag.Password = password.ToString();
            return View("Index");
        }
    }
}
