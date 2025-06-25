using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce_API.DTOs;
using E_Commerce_API.Models;
using E_Commerce_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_API.Controllers
{
    [ApiController]
    [Route("v1/api/catagories/")]
    public class CatagoryController : ControllerBase
    {
        private CatagoryService _catagoryService;
        public CatagoryController(CatagoryService catagoryService)
        {
            _catagoryService = catagoryService;
        }

        // GET /api/catagories/ => get catagories
        [HttpGet]
        public IActionResult GetCatagories()
        {

            var catagoryList = _catagoryService.GetAllCatagories();
            return Ok(ApiResponse<List<ReadCatagoryDto>>.SuccessResponse(catagoryList, 200, "Catagories returned successfully"));       // 200

        }

        [HttpGet("{catagoryId:guid}")]
        public IActionResult GetCatagoryById(Guid catagoryId)
        {
            var catagory = _catagoryService.GetCatagoryById(catagoryId);
            if (catagory == null)
            {
                return NotFound(ApiResponse<object>.ErrorResponse(new List<string> { "Catagory with this id does not exist." }, 404, "Validation Failed."));
            }

            return Ok(ApiResponse<ReadCatagoryDto>.SuccessResponse(catagory, 200, "Catagory returned successfully"));       // 200

        }

        // POST /api/catagories/ => Create a Catagory

        [HttpPost]
        public IActionResult CreateCatagory([FromBody] CreateCatagoryDto catagoryData)
        {

            var ResponseData = _catagoryService.CreateCatagory(catagoryData);

            // return Created($"api/catagories/{newCatagory.CatagoryId}", ApiResponse<ReadCatagoryDto>.SuccessResponse(ResponseData, 201, "Catagory created successfully"));       // 200

            return Created(nameof(GetCatagoryById), ApiResponse<ReadCatagoryDto>.SuccessResponse(ResponseData, 201, "Catagory created successfully"));       // 200


        }
        // PUT /api/catagories/{catagoryID} => Create a Catagory

        [HttpPut("{catagoryId:guid}")]
        public IActionResult UpdateCatagory(Guid catagoryId, [FromBody] UpdateCatagoryDto catagoryData)
        {
            var updateCatagory = _catagoryService.UpdateCatagoryById(catagoryId, catagoryData);       // 200
            if (updateCatagory == null)
            {
                return NotFound(ApiResponse<object>.ErrorResponse(new List<string> { "Catagory with this id does not exist." }, 404, "Validation Failed."));
            }

            return Ok(ApiResponse<ReadCatagoryDto>.SuccessResponse(updateCatagory, 200, "Catagories updated successfully"));

        }

        // DELETE /api/catagories/ => Delete a Catagory

        [HttpDelete("{catagoryId:guid}")]
        public IActionResult DeleteCatagory(Guid catagoryId)
        {
            var foundCatagory = _catagoryService.DeleteCatagoryById(catagoryId);       // 200
            if (!foundCatagory)
            {
                return NotFound(ApiResponse<object>.ErrorResponse(new List<string> { "Catagory with this id does not exist." }, 404, "Validation Failed."));
            }

            return Ok(ApiResponse<object>.SuccessResponse(null, 204, "Category deleted successfully."));

        }
     }
}