using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBuildingDal : IBuildingDal
    {


        public void Add(Building entity)
        {
            //IDisposable imp. of c#  garbage collector deleted after using it
            using (MysqlContext ctx = new MysqlContext())
            {
                var addedEntity = ctx.Entry(entity); //catch the referance
                addedEntity.State = EntityState.Added;
                ctx.SaveChanges();
            }
        }

        public void Delete(Building entity)
        {
            using (MysqlContext ctx = new MysqlContext())
            {
                var deletedEntity = ctx.Entry(entity); //catch the referance
                deletedEntity.State = EntityState.Deleted;
                ctx.SaveChanges();
            }
        }

        public Building Get(Expression<Func<Building, bool>> filter)
        {
            using (MysqlContext ctx = new MysqlContext())
            {
               return ctx.Set<Building>().SingleOrDefault(filter);
            }
        }

        public List<Building> GetAll(Expression<Func<Building, bool>> filter = null)
        {
            using (MysqlContext ctx = new MysqlContext())
            {
                return filter == null 
                    ? ctx.Set<Building>().ToList() 
                    : ctx.Set<Building>().Where(filter).ToList();
            }
        }

        public void Update(Building entity)
        {
            using (MysqlContext ctx = new MysqlContext())
            {
                var updatedEntity = ctx.Entry(entity); //catch the referance
                updatedEntity.State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }
    }
}
