using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BuildingTypeManager : IBuildingTypeService
    {
        IBuildingTypeDal _buildingTypeDal;

        public BuildingTypeManager(IBuildingTypeDal buildingTypeDal)
        {
            _buildingTypeDal = buildingTypeDal;
        }

        public List<BuildingType> GetAll()
        {
            return _buildingTypeDal.GetAll();
        }

        public BuildingType GetById(int Id)
        {
           return _buildingTypeDal.Get((item) => item.Id == Id);
        }
    }
}
