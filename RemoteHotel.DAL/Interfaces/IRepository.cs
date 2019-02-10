using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace RemoteHotel.DAL.Interfaces
{
    public interface IRepository<TEntity>
    {
        void Add(TEntity entity);
        void Remove(int id);
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        Object Find(Expression<Func<TEntity, bool>> predicate);
    }
}
    