using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBuildingDal : EfEntityRepositoryBase<Building, MysqlContext>, IBuildingDal
    {
        public List<BuildingDetailDto> GetBuildingDetails()
        {
            using (MysqlContext ctx = new MysqlContext())
            {
                var res = from b in ctx.Buildings
                          join bt in ctx.BuildingTypes
                          on b.BuildingType equals bt.Id
                          select new BuildingDetailDto
                          {
                              BuildingCost = b.BuildingCost,
                              BuildingId = b.Id,
                              BuildingType = bt.BType,
                              ConstructionTime = b.ConstructionTime
                          };

                return res.ToList();
            }
        }

        public List<BuildingDetailDto> GetBuildingDetailsByType(string type)
        {
            using (MysqlContext ctx = new MysqlContext())
            {
                var res = from b in ctx.Buildings
                          join bt in ctx.BuildingTypes
                          on b.BuildingType equals bt.Id
                          where bt.BType == type
                          select new BuildingDetailDto
                          {
                              BuildingCost = b.BuildingCost,
                              BuildingId = b.Id,
                              BuildingType = bt.BType,
                              ConstructionTime = b.ConstructionTime
                          };
                return res.ToList();

            }
        }
    }
}
