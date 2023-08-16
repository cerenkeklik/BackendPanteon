using Core.Entities;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class BuildingDetailDto: IDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId BuildingId { get; set; }
        public string BuildingType { get; set; }
        public int BuildingCost { get; set; }
        public int ConstructionTime { get; set; }
    }
}
