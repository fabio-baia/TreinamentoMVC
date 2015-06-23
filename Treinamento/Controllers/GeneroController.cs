using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Treinamento.Context;
using Treinamento.Models;

namespace Treinamento.Controllers
{
    public class GeneroController : Controller
    {
        private readonly LojaContext _db = new LojaContext();

        public ActionResult Index()
        {
            return View(_db.Generos.ToList());
        }

        public ActionResult List()
        {
            return View(_db.Generos.ToList());
        }

    }
}
