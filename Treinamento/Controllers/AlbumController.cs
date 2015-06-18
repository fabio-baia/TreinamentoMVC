﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Treinamento.Context;
using Treinamento.Models;

namespace Treinamento.Controllers
{
    public class AlbumController : Controller
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

        public ActionResult Editar(Album album)
        {
            return View();
        }

        public ActionResult Busca(string q)
        {
            //var albums = from album in db.Albums
            //    orderby album.Titulo ascending
            //    where album.Titulo.Contains(q)
            //    select album;

            IQueryable<Album> albums = db.Albums;
            if (!string.IsNullOrWhiteSpace(q))
                albums = albums.Where(a => a.Titulo.Contains(q));
            return View(albums.ToList());
        }
    }
}
