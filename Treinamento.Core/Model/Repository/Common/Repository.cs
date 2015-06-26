using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using Treinamento.Core.Context;

namespace Treinamento.Core.Model.Repository.Common
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly TreinamentoContext _context;
        private readonly IDbSet<TEntity> _dbSet;
        private DbContextTransaction _dbContextTransaction;

        public Repository(TreinamentoContext context, IDbSet<TEntity> dbSet)
        {
            _context = context;
            _dbSet = dbSet;
        }

        protected TreinamentoContext Context {
            get { return _context;}
        }

        protected IDbSet<TEntity> DbSet
        {
            get { return _dbSet; }
        }

        public virtual void Save(TEntity entity)
        {
            DbSet.AddOrUpdate(entity);
        }

        public virtual void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            var entry = Context.Entry(entity);
            DbSet.Attach(entity);
            entry.State = EntityState.Modified;
        }

        public virtual void Delete(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public virtual void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public virtual TEntity Find(int id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<TEntity> All(bool @readonly)
        {
            return @readonly ? DbSet.AsNoTracking() : DbSet;
        }

        public virtual IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate, bool @readonly = false)
        {
            return @readonly ? DbSet.Where(predicate).AsNoTracking() : DbSet.Where(predicate);
        }

        public void BeginTransaction()
        {
            _dbContextTransaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _dbContextTransaction.Commit();
        }

        public void Rollback()
        {
            _dbContextTransaction.Rollback();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) return;
            if (Context == null) return;
            Context.Dispose();
        }
    }
}