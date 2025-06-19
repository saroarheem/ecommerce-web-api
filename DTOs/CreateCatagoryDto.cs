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
        [Required]
        public string Name { set; get; }
        public string Description { set; get; } = string.Empty;
    }
}