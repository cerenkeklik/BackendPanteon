﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class BuildingDetailDto: IDto
    {
        public int BuildingId { get; set; }
        public string BuildingType { get; set; }
        public int BuildingCost { get; set; }
        public int ConstructionTime { get; set; }
    }
}