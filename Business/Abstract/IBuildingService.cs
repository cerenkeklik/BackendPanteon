using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBuildingService
    {
        IDataResult<List<Building>> GetAll();
        IDataResult<List<BuildingDetailDto>> GetBuildingDetails();
        IDataResult<List<BuildingDetailDto>> GetByType(string buildingType);
        IResult Add(Building building);
    }
}
