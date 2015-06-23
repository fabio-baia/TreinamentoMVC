using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Treinamento.Context;
using Treinamento.Models;

namespace Treinamento.Controllers
{
    public class AlbumController : BaseController
    {
        private LojaContext db = new LojaContext();

        public ActionResult Index()
        {
            //using linq
            //var albums = from album in db.Albums
            //    orderby album.Titulo ascending
            //    select album;

            //using lambda
            var albums = db.Albums.OrderBy(q => q.Titulo);

            //order with multi params and where clause
            //var albums = db.Albums.OrderBy(q => new
            //{
            //    q.Titulo,
            //    q.Genero.Descricao
            //}).Where(q => q.Titulo.StartsWith("a"));

            
            return View(albums.ToList());
        }

        public ActionResult Editar()
        {
            return View("Editar");
        }

        [HttpPost]
        public ActionResult Editar(Album album)
        {
            ModelState.AddModelError("Titulo", "Que nome horrível");
            return View();
        }

        public ActionResult Busca(string busca)
        {
            //var albums = from album in db.Albums
            //    orderby album.Titulo ascending
            //    where album.Titulo.Contains(q)
            //    select album;

            IQueryable<Album> albums = db.Albums;
            if (!string.IsNullOrWhiteSpace(busca))
                albums = albums.Where(a => a.Titulo.Contains(busca));

            ViewBag.IdGenero = new SelectList(db.Generos.OrderBy(g => g.Nome), "Id", "Nome");

            return View(albums.ToList());
        }
    }
}
