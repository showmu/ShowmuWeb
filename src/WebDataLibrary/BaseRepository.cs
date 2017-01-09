using InterfaceDataLibrary;
using System;
using System.Linq;
using System.Linq.Expressions;
using WebModels.Data;
using Microsoft.EntityFrameworkCore;

namespace WebDataLibrary
{
    public class BaseRepository<T> : InterfaceBaseRepository<T> where T : class
    {
        protected ApplicationDbContext _Context;
      
      
        public BaseRepository(ApplicationDbContext context)
        {
            _Context = context;
        }

        public IQueryable<T> Entities
        {
            get
            {
                return _Context.Set<T>();
            }
        }

        public T Add(T entity, bool isSave = true)
        {
            _Context.Set<T>().Add(entity);
            if (isSave) _Context.SaveChanges();
            return entity;
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            return _Context.Set<T>().Count(predicate);
        }

        public bool Delete(T entity, bool isSave = true)
        {
            _Context.Set<T>().Attach(entity);
            _Context.Entry<T>(entity).State = EntityState.Deleted;
            return !isSave || _Context.SaveChanges() > 0;
        }

        public bool Exist(Expression<Func<T, bool>> anyLambda)
        {
            return _Context.Set<T>().Any(anyLambda);
        }

      
        public T Find(Expression<Func<T, bool>> whereLambda)
        {
            T entity = _Context.Set<T>().FirstOrDefault<T>(whereLambda);
            return entity;
        }

        public IQueryable<T> LoadEntities(Func<T, bool> wherelambda)
        {
            return _Context.Set<T>().Where<T>(wherelambda).AsQueryable();

        }

        public IQueryable<T> LoadPagerEntities<TS>(int pageSize, int pageIndex, out int total, Func<T, bool> whereLambda, bool isAsc, Func<T, TS> orderByLambda)
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            return _Context.SaveChanges();
        }

        public bool Update(T entity, bool isSave = true)
        {
            _Context.Set<T>().Attach(entity);
            _Context.Entry<T>(entity).State =EntityState.Modified;
            return !isSave || _Context.SaveChanges() > 0;
        }
    }
}
