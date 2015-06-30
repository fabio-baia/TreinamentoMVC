using System;
using System.Linq;
using System.Linq.Expressions;
using Treinamento.Core.Model;
using Treinamento.Core.Model.Repository.Interface;
using Treinamento.Core.Service.Interfaces;

namespace Treinamento.Core.Service
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _repository;

        public PessoaService(IPessoaRepository repository)
        {
            _repository = repository;
        }

        public Pessoa Find(int id)
        {
            return _repository.Find(id);
        }

        public IQueryable<Pessoa> All(bool @readonly = false)
        {
            return _repository.All(@readonly);
        }

        public IQueryable<Pessoa> Query(Expression<Func<Pessoa, bool>> predicate, bool @readonly = false)
        {
            return _repository.Query(predicate, @readonly);
        }

        public void Save(Pessoa entity)
        {
            _repository.BeginTransaction();
            _repository.Save(entity);
            _repository.Commit();
        }

        public void Create(Pessoa entity)
        {
            _repository.BeginTransaction();
            _repository.Add(entity);
            _repository.Commit();
        }

        public void Update(Pessoa entity)
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

        public void Delete(Pessoa entity)
        {
            _repository.BeginTransaction();
            _repository.Delete(entity);
            _repository.Commit();
        }
    }
}
