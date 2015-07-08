using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Treinamento.Controllers;
using Treinamento.Core.Model;
using Treinamento.Core.Service.Interfaces;
using Treinamento.Testes.Factory;
using Treinamento.Testes.Services;

namespace Treinamento.Testes.Controllers
{
    [TestClass]
    public class CidadeControllerTest
    {
        public CidadeController GetCidadeController(ICidadeService service)
        {
            var controller = new CidadeController(service);
            controller.ControllerContext = new ControllerContext(new RequestContext(), controller);

            return controller;
        }

        [TestMethod]
        public void Index_Get_AskForIndexView()
        {
            //arrange
            var controller = GetCidadeController(new InMemoryCidadeServices());

            //act
            ViewResult result = (ViewResult)controller.Index();

            //assert
            Assert.IsNotNull(result.ViewName);
        }

        [TestMethod]
        public void Index_Get_RetrieveAllCidadesFromRepository()
        {
            //arrange
            Cidade cidade1 = CidadeFactory.Create(1, "Maringá", "PR");
            Cidade cidade2 = CidadeFactory.Create(2, "Anta Gorda", "RS");

            var repository = new InMemoryCidadeServices();
            repository.Save(cidade1);
            repository.Save(cidade2);

            var controller = GetCidadeController(repository);

            //act
            JsonResult result = (JsonResult)controller.AjaxList();

            //assert
            var model = ((IEnumerable<Cidade>)result.Data).ToList();

            CollectionAssert.Contains(model.ToList(), cidade1);
            CollectionAssert.Contains(model.ToList(), cidade2);
        }

        [TestMethod]
        public void Create_Post_PutsValidCidadeIntoRepository()
        {
            //arrange
            InMemoryCidadeServices repository = new InMemoryCidadeServices();
            CidadeController controller = GetCidadeController(repository);

            Cidade cidade = CidadeFactory.Create(1, "Maringá", "PR");

            //act
            controller.AjaxAdd(cidade);

            IEnumerable<Cidade> cidades = repository.All();
            Assert.IsTrue(cidades.Contains(cidade));
        }
    }
}
