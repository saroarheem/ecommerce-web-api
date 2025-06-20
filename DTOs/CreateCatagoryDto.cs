using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace E_Commerce_API.DTOs
{
    public class CreateCatagoryDto
    {
        [Required(ErrorMessage = "Catagory name is required!!")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Catagory name must be between 2 to 100 character.")]
        public string Name { set; get; } = string.Empty;

        [StringLength(500, ErrorMessage = "Catagory description cannot exceed 500 characters.")]
        public string Description { set; get; } = string.Empty;
    }
}