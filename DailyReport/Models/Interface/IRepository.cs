using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace DailyReport.Models.Interface
{
    public interface IRepository<TEntity> : IDisposable
         where TEntity : class
    {
        void Create(TEntity instance);

        void Update(TEntity instance);

        void Delete(TEntity instance);

        //  TEntity Get(int primaryID);

        void DeleteAll(Expression<Func<TEntity, bool>> predicate);


        TEntity Get(Expression<Func<TEntity, bool>> predicate);


        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetByParm(Expression<Func<TEntity, bool>> predicate);



        void SaveChanges();

    }
}