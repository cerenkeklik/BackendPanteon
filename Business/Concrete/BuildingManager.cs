using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        public IDataResult<List<int>> GetAvailableTypes(string username)
        {
            var existings = _buildingDal.GetAll(item => item.Username == username);
            var availables = new List<int> { 1, 2, 3, 4, 5 };

            foreach (var item in existings)
            {
                availables.RemoveAll(p => p == item.BuildingType);
            }
            return new DataResult<List<int>>(availables, true);
        }

        public IDataResult<List<Building>> GetByUsername(string username)
        {
            return new DataResult<List<Building>>(_buildingDal.GetAll(item => item.Username == username), true);
        }
    }
}
