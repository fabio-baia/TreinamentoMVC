using System;
using System.Linq;
using System.Linq.Expressions;

namespace Treinamento.Core.Service.Common
{
    public interface IService<TEntity>
    {
        TEntity Find(int id);
        IQueryable<TEntity> All(bool @readonly = false);
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate, bool @readonly = false);
        void Save(TEntity entity);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
        void Delete(TEntity entity);
    }
}