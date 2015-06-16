using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Treinamento.Controllers
{
    public class WelcomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public string Browse(string genre)
        {
            string message = HttpUtility.HtmlEncode("Welcome.Browse, Genre = " + genre);
            return message;
        }

        public string Details(int id)
        {
            return "Welcome.Details, ID = " + id;
        }
    }
}
