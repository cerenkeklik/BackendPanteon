using Core.Entities.Concrete;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Mongo
{
    public class MongoContext
    {
        public IMongoDatabase db { get; set; }
        public MongoClient mongoClient { get; set; }
        public IClientSessionHandle Session { get; set; }
        public MongoContext(IOptions<Mongosettings> configuration)
        {
            mongoClient = new MongoClient(configuration.Value.ConnectionString);
            db = mongoClient.GetDatabase(configuration.Value.DatabaseName);
        }
    }
}
