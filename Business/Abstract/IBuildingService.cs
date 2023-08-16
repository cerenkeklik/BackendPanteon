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
        IResult Add(Building building);
        IDataResult<List<Building>> GetByUsername(string username);
        IDataResult<List<int>> GetAvailableTypes(string username);

    }
}
