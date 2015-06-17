using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Treinamento.Context;

namespace Treinamento.Controllers
{
    public class AlbumController : Controller
    {
        private LojaContext db = new LojaContext();

        public ActionResult Index()
        {
            var albums = db.Albums.Include(a => a.Artista).Include(a => a.Genero);
            return View(albums.ToList());
        }

    }
}
