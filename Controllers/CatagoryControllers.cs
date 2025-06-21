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

            return Ok(ApiResponse<List<ReadCatagoryDto>>.SuccessResponse( catagoryList, 200,"Catagories returned successfully"));       // 200

        }

        // POST /api/catagories/ => Create a Catagory

        [HttpPost]
        public IActionResult CreateCatagory([FromBody] CreateCatagoryDto catagoryData)
        {

            var newCatagory = new Catagory
            {
                CatagoryId = Guid.NewGuid(),
                Name = catagoryData.Name,
                Description = catagoryData.Description,
                CreatedAt = DateTime.UtcNow
            };

            catagories.Add(newCatagory);
            var ResponseData = new ReadCatagoryDto
            {
                CatagoryId = newCatagory.CatagoryId,
                Name = newCatagory.Name,
                Description = newCatagory.Description,
                CreatedAt = newCatagory.CreatedAt
            };
            return Created($"api/catagories/{newCatagory.CatagoryId}", ApiResponse<ReadCatagoryDto>.SuccessResponse( ResponseData, 201,"Catagory created successfully"));       // 200


        }
        // PUT /api/catagories/{catagoryID} => Create a Catagory

        [HttpPut("{catagoryId:guid}")]
        public IActionResult UpdateCatagory(Guid catagoryId,[FromBody] UpdateCatagoryDto? catagoryData)
        {
            var foundCatagory = catagories.FirstOrDefault(catagory => catagory.CatagoryId == catagoryId);       // 200
            if (foundCatagory == null)
            {
                return NotFound(ApiResponse<object>.ErrorResponse(new List<string> {"Catagory with this id does not exist."},404,"Validation Failed."));
            }
               
            foundCatagory.Name = catagoryData.Name;
            foundCatagory.Description = catagoryData.Description;

            return Ok(ApiResponse<object>.SuccessResponse( null, 204,"Catagories updated successfully"));

        }

        // DELETE /api/catagories/ => Delete a Catagory

        [HttpDelete("{catagoryId:guid}")]
        public IActionResult DeleteCatagory(Guid catagoryId)
        {
            var foundCatagory = catagories.FirstOrDefault(catagory => catagory.CatagoryId == catagoryId);       // 200
            if (foundCatagory == null)
            {
                return NotFound(ApiResponse<object>.ErrorResponse(new List<string> {"Catagory with this id does not exist."},404,"Validation Failed."));
            }
            catagories.Remove(foundCatagory);
            return Ok(ApiResponse<object>.SuccessResponse(null, 204, "Category deleted successfully."));

        }
    }
}