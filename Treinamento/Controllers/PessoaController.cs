using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Treinamento.Core.Model;
using Treinamento.Core.Service.Interfaces;

namespace Treinamento.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IPessoaService _pessoaService;
        private readonly ICidadeService _cidadeService;

        public PessoaController(IPessoaService pessoaService, ICidadeService cidadeService)
        {
            _pessoaService = pessoaService;
            _cidadeService = cidadeService;
        }

        public ActionResult Index()
        {
            return View(_pessoaService.All().Include(c => c.Cidade));
        }

        public ActionResult Create(int id = 0)
        {
            var pessoa = _pessoaService.Find(id) ?? new Pessoa();

            DropDown(pessoa);

            return View(pessoa);
        }

        private void DropDown(Pessoa pessoa)
        {
            var cidades = pessoa.Cidade == null ? new List<Cidade>() : _cidadeService.Query(q => q.Uf == pessoa.Cidade.Uf).ToList();
            
            ViewBag.Estados = new SelectList(_cidadeService.ListarEstados(), pessoa.Cidade.IfNotNull(q => q.Uf));
            ViewBag.IdCidade = new SelectList(cidades, "Id", "Nome", pessoa.IdCidade);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pessoa pessoa)
        {
            var isNew = pessoa.Id == 0;

            if (!ModelState.IsValid)
            {
                DropDown(pessoa);
                return View(pessoa);
            }

            _pessoaService.Save(pessoa);
            return isNew ? RedirectToAction("Create", new {pessoa.Id}) : RedirectToAction("Index");
        }
        
        public ActionResult Delete(int id)
        {
            var pessoa = _pessoaService.Find(id);
            if (pessoa == null)
                return HttpNotFound();
            
            return View(pessoa);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _pessoaService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
