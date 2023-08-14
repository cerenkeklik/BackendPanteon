using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
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

        public IResult Add(Building building)
        {
           
            if(building.BuildingCost <= 0) 
                return new ErrorResult(Messages.BuildingCostInvalid);

            if(building.ConstructionTime < 30 || building.ConstructionTime > 1800) 
                return new ErrorResult(Messages.ConstructionTimeInvalid);

            _buildingDal.Add(building);
            return new SuccessResult(Messages.BuildingAdded);
        }

        public IDataResult<List<Building>> GetAll()
        {
            //use if clauses here
            return new DataResult<List<Building>>(_buildingDal.GetAll(), true);
        }

        public IDataResult<List<BuildingDetailDto>> GetBuildingDetails()
        {
            return new SuccessDataResult<List<BuildingDetailDto>>(_buildingDal.GetBuildingDetails());
        }

        public IDataResult<List<BuildingDetailDto>> GetByType(string buildingType)
        {
            return new SuccessDataResult<List<BuildingDetailDto>>(_buildingDal.GetBuildingDetailsByType(buildingType));
        }
    }
}
