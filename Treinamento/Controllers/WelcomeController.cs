using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Treinamento.Controllers
{
    public class WelcomeController : Controller
    {
        //
        // GET: /Welcome/

        public string Index()
        {
            return "Hello World";
        }

        public string OutraAction()
        {
            return "Outra Action";
        }

    }
}
