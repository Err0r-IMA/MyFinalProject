using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFreamwork
{
    //NuGet
    public class EfProductDal : IProductDal
    {

        public void Add(Product entity)
        {
            //IDisposable pattern implementation of C#
            using (NorthwindContext context = new NorthwindContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }

        }
        //ada, sınıf, yaş ....
        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);

            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filtre = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filtre == null 
                    ? context.Set<Product>().ToList() 
                    : context.Set<Product>().Where(filtre).ToList();

                
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }


}
