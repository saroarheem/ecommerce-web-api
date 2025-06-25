using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce_API.DTOs;
using E_Commerce_API.Models;


namespace E_Commerce_API.Services
{
    public class CatagoryService
    {
        private static readonly List<Catagory> _catagories = new List<Catagory>();
        public List<ReadCatagoryDto> GetAllCatagories()
        {
            return _catagories.Select(c => new ReadCatagoryDto
            {
                CatagoryId = c.CatagoryId,
                Name = c.Name,
                Description = c.Description,
                CreatedAt = c.CreatedAt
            }).ToList();
        }

        public ReadCatagoryDto? GetCatagoryById(Guid catagoryId)
        {
            var foundCatagory = _catagories.FirstOrDefault(c => c.CatagoryId == catagoryId);
            if (foundCatagory == null)
            {
                return null;
            }

            return new ReadCatagoryDto
            {
                CatagoryId = foundCatagory.CatagoryId,
                Name = foundCatagory.Name,
                Description = foundCatagory.Description,
                CreatedAt = foundCatagory.CreatedAt
            };
        }

        public ReadCatagoryDto CreateCatagory(CreateCatagoryDto catagoryData)
        {
            var newCatagory = new Catagory
            {
                CatagoryId = Guid.NewGuid(),
                Name = catagoryData.Name,
                Description = catagoryData.Description,
                CreatedAt = DateTime.UtcNow
            };

            _catagories.Add(newCatagory);
            return new ReadCatagoryDto
            {
                CatagoryId = newCatagory.CatagoryId,
                Name = newCatagory.Name,
                Description = newCatagory.Description,
                CreatedAt = newCatagory.CreatedAt
            };
        }

        public ReadCatagoryDto? UpdateCatagoryById(Guid catagoryId, UpdateCatagoryDto catagoryData)
        {
            var foundCatagory = _catagories.FirstOrDefault(catagory => catagory.CatagoryId == catagoryId);       // 200
            if (foundCatagory == null)
            {
                return null;
            }
            if (catagoryData.Name != null)
                foundCatagory.Name = catagoryData.Name;
            if (catagoryData.Description != null)
                foundCatagory.Description = catagoryData.Description;

            return new ReadCatagoryDto
            {
                CatagoryId = foundCatagory.CatagoryId,
                Name = foundCatagory.Name,
                Description = foundCatagory.Description,
                CreatedAt = foundCatagory.CreatedAt
            };
        }

        public bool DeleteCatagoryById(Guid catagoryId)
        {
            var foundCatagory = _catagories.FirstOrDefault(catagory => catagory.CatagoryId == catagoryId);       // 200
            if (foundCatagory == null)
            {
                return false;
            }
            _catagories.Remove(foundCatagory);
            return true;
        }
    }
}