using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Building: IEntity
    {
        public int Id { get; set; }
        public int BuildingType { get; set; }
        public int BuildingCost { get; set; }
        public DateTime ConstructionTime { get; set; }
    }
}
