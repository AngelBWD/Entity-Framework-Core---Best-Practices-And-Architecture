﻿using RealEstates.Services.Models;

namespace RealEstates.Services
{-
    public interface IPropertiesService
    {
        void Add(string district, int price, int floor, int maxFloor, int size,
            int yarnSize, int year, string propertyType, string buildingType);

        IEnumerable<PropertyInfoDto> Search(int minPrice, int maxPrice, int minSize, int maxSize);
    }
}
