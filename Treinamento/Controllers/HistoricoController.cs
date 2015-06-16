using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Treinamento.Controllers
{
    public class HistoricoController : Controller
    {
        public string Arquivo(DateTime data)
        {
            return string.Format("A data é {0:D}", data);
        }
    }
}
