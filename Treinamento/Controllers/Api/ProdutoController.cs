using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Treinamento.Core.Context;
using Treinamento.Core.Model;

namespace Treinamento.Controllers.Api
{
    public class ProdutoController : ApiController
    {
        private readonly TreinamentoContext db = new TreinamentoContext();

        public IQueryable<Produto> Get()
        {
            return db.Produtos;
        }

        [ResponseType(typeof(Produto))]
        public IHttpActionResult Get(int id)
        {
            var produto = db.Produtos.Find(id);
            if (produto == null)
                return NotFound();
            return Ok(produto);
        }

        [ResponseType(typeof(Produto))]
        public IHttpActionResult Put(Produto produto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.Entry(produto).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(produto.Id))
                    return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(Produto))]
        public IHttpActionResult Post(Produto produto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            db.Produtos.Add(produto);
            db.SaveChanges();

            return Ok(produto);
        }

        [ResponseType(typeof (Produto))]
        public IHttpActionResult Delete(int id)
        {
            var produto = db.Produtos.Find(id);
            if(produto == null)
                return NotFound();

            db.Produtos.Remove(produto);
            db.SaveChanges();

            return Ok(produto);
        }

        private bool ProdutoExists(int id)
        {
            return db.Produtos.Any(e => e.Id == id);
        }
    }
}
