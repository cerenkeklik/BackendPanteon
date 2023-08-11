using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BuildingManager : IBuildingService
    {
        IBuildingDal _buildingDal;

        public BuildingManager(IBuildingDal buildingDal) 
            //when created new building manager gets me the building dal inmemory or ef etc.
        {
            _buildingDal = buildingDal;
        }

        public List<Building> GetAll()
        {
            //use if clauses here
            return _buildingDal.GetAll();
        }
    }
}
