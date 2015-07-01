using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Treinamento.Core.Model;
using Treinamento.Core.Model.Repository.Interface;
using Treinamento.Core.Service.Interfaces;

namespace Treinamento.Core.Service
{
    public class CidadeService : ICidadeService
    {
        private readonly ICidadeRepository _repository;

        public CidadeService(ICidadeRepository repository)
        {
            _repository = repository;
        }

        public Cidade Find(int id)
        {
            return _repository.Find(id);
        }

        public IQueryable<Cidade> All(bool @readonly = false)
        {
            return _repository.All(@readonly);
        }

        public IQueryable<Cidade> Query(Expression<Func<Cidade, bool>> predicate, bool @readonly = false)
        {
            return _repository.Query(predicate, @readonly);
        }

        public void Save(Cidade entity)
        {
            _repository.BeginTransaction();
            _repository.Save(entity);
            _repository.Commit();
        }

        public void Create(Cidade entity)
        {
            _repository.BeginTransaction();
            _repository.Add(entity);
            _repository.Commit();
        }

        public void Update(Cidade entity)
        {
            _repository.BeginTransaction();
            _repository.Update(entity);
            _repository.Commit();
        }

        public void Delete(int id)
        {
            _repository.BeginTransaction();
            _repository.Delete(id);
            _repository.Commit();
        }

        public void Delete(Cidade entity)
        {
            _repository.BeginTransaction();
            _repository.Delete(entity);
            _repository.Commit();
        }

        public IQueryable<string> ListarEstados()
        {
            return All().GroupBy(q => q.Uf).Select(q => q.Key);
        }
    }
}
