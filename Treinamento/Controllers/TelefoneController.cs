using System.Linq;
using System.Web.Mvc;
using Treinamento.Core.Model;
using Treinamento.Core.Service.Interfaces;

namespace Treinamento.Controllers
{
    public class TelefoneController : Controller
    {
        private readonly ITelefoneService telefoneService;

        public TelefoneController(ITelefoneService telefoneService)
        {
            this.telefoneService = telefoneService;
        }

        public ActionResult AjaxAdd(Telefone telefone)
        {
            if (!ModelState.IsValid)
                return Json(new{Message = ModelState.Values.Select(q => q.Value), Status = false});

            telefoneService.Save(telefone);
            return Json(new{Status = true});
        }

        public ActionResult AjaxRemove(int id)
        {
            telefoneService.Delete(id);
            return Json(new{Status = true}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AjaxList(int id)
        {
            return PartialView(telefoneService.Query(q => q.IdPessoa == id));
        }

        public ActionResult DialogForm()
        {
            return PartialView(new Telefone());
        }
    }
}