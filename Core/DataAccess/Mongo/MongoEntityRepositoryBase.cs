using Core.Entities;
using Core.Entities.Concrete;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Mongo
{
    public class MongoEntityRepositoryBase<TEntity> : IEntityRepository<TEntity>
         where TEntity : class, IEntity, new()
    {
        protected readonly IMongoCollection<TEntity> Collection;
        private readonly Mongosettings settings;
        private IOptions<Mongosettings> options;

        public MongoEntityRepositoryBase(IConfiguration configuration)
        {
            var ConnectionString = configuration
                    .GetSection(nameof(Mongosettings) + ":" + Mongosettings.ConnectionStringValue).Value;

            var DatabaseName = configuration
                    .GetSection(nameof(Mongosettings) + ":" + Mongosettings.DatabaseValue).Value;

            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DatabaseName);
            this.Collection = db.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public void Add(TEntity entity)
        {
            Collection.InsertOne(entity);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return (TEntity)Collection.Find(filter);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null 
                ? Collection.FindAsync(Builders<TEntity>.Filter.Empty).Result.ToList()
                : Collection.FindAsync(filter).Result.ToList();
        }

    }
}
