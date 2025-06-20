using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce_API.DTOs;
using E_Commerce_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_API.Controllers
{
    [ApiController]
    [Route("api/catagories/")]
    public class CatagoryController : ControllerBase
    {
        public static List<Catagory> catagories = new List<Catagory>();

        // GET /api/catagories/ => get catagories
        [HttpGet]
        public IActionResult GetCatagories([FromQuery] string searchValue = "")
        {
            // if (!string.IsNullOrEmpty(searchValue))
            // {
            //     var searchCatagory = catagories.Where(c => c.Name.Contains(searchValue, StringComparison.OrdinalIgnoreCase)).ToList();
            //     return Ok(searchCatagory);
            // }

            var catagoryList = catagories.Select(c => new ReadCatagoryDto
            {
                CatagoryId = c.CatagoryId,
                Name = c.Name,
                Description = c.Description,
                CreatedAt = c.CreatedAt
            }).ToList();

            return Ok(catagoryList);       // 200

        }

        // POST /api/catagories/ => Create a Catagory

        [HttpPost]
        public IActionResult CreateCatagory([FromBody] CreateCatagoryDto catagoryData)
        {
            if (!ModelState.IsValid)
            {
                
            }

            var newCatagory = new Catagory
            {
                CatagoryId = Guid.NewGuid(),
                Name = catagoryData.Name,
                Description = catagoryData.Description,
                CreatedAt = DateTime.UtcNow
            };

            catagories.Add(newCatagory);
            var ReadCatagoryDto = new ReadCatagoryDto
            {
                CatagoryId = newCatagory.CatagoryId,
                Name = newCatagory.Name,
                Description = newCatagory.Description,
                CreatedAt = newCatagory.CreatedAt
            };
            return Created($"api/catagories/{newCatagory.CatagoryId}", ReadCatagoryDto);       // 200


        }
        // PUT /api/catagories/{catagoryID} => Create a Catagory

        [HttpPut("{catagoryId:guid}")]
        public IActionResult UpdateCatagory(Guid catagoryId,[FromBody] UpdateCatagoryDto? catagoryData)
        {
            if (catagoryData == null)
            {
                return BadRequest("Catagory data is missing.");
            }

            var foundCatagory = catagories.FirstOrDefault(catagory => catagory.CatagoryId == catagoryId);       // 200
            if (foundCatagory == null)
            {
                return NotFound("Catagory with this id does not exist.");
            }
            if (!string.IsNullOrWhiteSpace(catagoryData.Name))
            {
                if (catagoryData.Name.Length >= 2)
                {
                    foundCatagory.Name = catagoryData.Name;
                }
                else
                {
                    return BadRequest("Name must be at least 2 character");
                }
            }
            if (!string.IsNullOrWhiteSpace(catagoryData.Description))
            {
                foundCatagory.Description = catagoryData.Description;
            }

            return NoContent();

        }

        // DELETE /api/catagories/ => Delete a Catagory

        [HttpDelete("{catagoryId:guid}")]
        public IActionResult DeleteCatagory(Guid catagoryId)
        {
            var foundCatagory = catagories.FirstOrDefault(catagory => catagory.CatagoryId == catagoryId);       // 200
            if (foundCatagory == null)
            {
                return NotFound("Catagory with this id does not exist.");
            }
            catagories.Remove(foundCatagory);
            return NoContent();

        }
    }
}