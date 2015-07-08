using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Treinamento.Core.Model;
using Treinamento.Core.Service.Interfaces;

namespace Treinamento.Testes.Services
{
    public class InMemoryCidadeServices : ICidadeService
    {
        private List<Cidade> _db = new List<Cidade>();

        public Cidade Find(int id)
        {
            return _db.FirstOrDefault(q => q.Id == id);
        }

        public IQueryable<Cidade> All(bool @readonly = false)
        {
            return _db.AsQueryable();
        }

        public IQueryable<Cidade> Query(Expression<Func<Cidade, bool>> predicate, bool @readonly = false)
        {
            return _db.Where(predicate.Compile()).AsQueryable();
        }

        public void Save(Cidade entity)
        {
            _db.Add(entity);
        }

        public void Create(Cidade entity)
        {
        }

        public void Update(Cidade entity)
        {
        }

        public void Delete(int id)
        {
            Delete(Find(id));
        }

        public void Delete(Cidade entity)
        {
            _db.Remove(entity);
        }

        public IQueryable<string> ListarEstados()
        {
            return _db.GroupBy(q => q.Uf).Select(q => q.Key).AsQueryable();
        }
    }
}
