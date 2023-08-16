using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using Core.DataAccess.Mongo;
using Core.Entities;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Mongo
{
    public class MongoBuildingDal : MongoEntityRepositoryBase<Building>, IBuildingDal
    {
        public MongoBuildingDal(IConfiguration configuration) : base(configuration)
        {
        }

        public List<BuildingDetailDto> GetBuildingDetails()
        {
            throw new NotImplementedException();
        }

        public List<BuildingDetailDto> GetBuildingDetailsByType(string type)
        {
            throw new NotImplementedException();
        }
    }

}
