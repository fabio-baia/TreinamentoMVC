using System.Web.Mvc;
using Treinamento.Core.Model;
using Treinamento.Core.Service.Interfaces;

namespace Treinamento.Controllers
{
    public class CidadeController : Controller
    {
        private readonly ICidadeService _cidadeService;

        public CidadeController(ICidadeService cidadeService)
        {
            _cidadeService = cidadeService;
        }

        public ActionResult AjaxOption(string uf)
        {
            return PartialView(_cidadeService.Query(q => q.Uf == uf));
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult AjaxList()
        {
            return Json(_cidadeService.All(true), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AjaxAdd(Cidade cidade)
        {
            _cidadeService.Save(cidade);
            return Json(new{Status= true, Model = cidade});
        }

        public JsonResult AjaxRemove(int id)
        {
            _cidadeService.Delete(id);
            return Json(new{Status= true});
        }
    }
}
