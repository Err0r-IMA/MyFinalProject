using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //genreic costraint
    //class : referans tip olabilir.
    //IEntity : IEntity olabilir vrya IEntity  implemente eden bir nesne olabilir.
    //new() : new'lenebilir olmalı.

    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        
        List<T> GetAll(Expression<Func<T,bool>> filtre=null);
        
        T Get(Expression<Func<T, bool >> filter);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
        
    }
}
