using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBuildingDal : IBuildingDal
    {
        List<Building> _buildings;

        public InMemoryBuildingDal()
        {
            _buildings = new List<Building>
            {
               new Building{BuildingCost= 1000, BuildingType=1, ConstructionTime= 35},
                new Building{BuildingCost= 12000, BuildingType=2, ConstructionTime= 40}
            };
        }
        public void Add(Building building)
        {
            _buildings.Add(building);
        }

        public void Delete(Building building)
        {
            Building buildingToDelete = _buildings.Single((item) => item._id == building._id);
           _buildings.Remove(buildingToDelete);
        }

        public Building Get(Expression<Func<Building, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Building> GetAll(Expression<Func<Building, bool>> filter = null)
        {
            return _buildings;
        }

        public List<BuildingDetailDto> GetBuildingDetails()
        {
            throw new NotImplementedException();
        }

        public List<BuildingDetailDto> GetBuildingDetailsByType(string type)
        {
            throw new NotImplementedException();
        }

        public void Update(Building building)
        {
            Building buildingToUpdate = _buildings.Single((item) => item._id == building._id);
            buildingToUpdate.BuildingCost = building.BuildingCost;
            buildingToUpdate.BuildingType = building.BuildingType;
            buildingToUpdate.ConstructionTime = building.ConstructionTime;
        }
    }
}
