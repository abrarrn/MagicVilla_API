﻿using WebApplication1.Models.Dto;

namespace WebApplication1.Data
{
    public static class VillaStore
    {
        public static List<VillaDTO> villaList = new List<VillaDTO>
        {
            new VillaDTO{Id=1, Name="Pool View", Occupancy="4", Area="100 sqft"},
            new VillaDTO{Id=2, Name="Beach View", Occupancy = "4", Area="100 sqft"}
        };
    }
}
