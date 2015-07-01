using System.Web.Mvc;
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

    }
}
