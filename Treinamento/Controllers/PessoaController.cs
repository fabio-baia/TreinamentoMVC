using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            return View(_pessoaService.All());
        }

        public ActionResult Create(int id = 0)
        {
            ViewBag.Estados = new SelectList(_cidadeService.ListarEstados());

            return View(_pessoaService.Find(id) ?? new Pessoa());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pessoa pessoa)
        {
            if (!ModelState.IsValid)
                return View(pessoa);

            _pessoaService.Save(pessoa);
            return RedirectToAction("Index");
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
