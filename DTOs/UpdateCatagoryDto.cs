using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_API.DTOs
{
    public class UpdateCatagoryDto
    {
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Catagory name must be between 2 to 100 characters")]

        public string? Name { set; get; }

        [StringLength(500, MinimumLength = 2, ErrorMessage = "Catagory Description must be between 2 to 500 characters")]
        public string? Description { set; get; }
   
    }
}