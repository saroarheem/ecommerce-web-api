using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_API.DTOs
{
    public class UpdateCatagoryDto
    {
        public string Name { set; get; }
        public string Description { set; get; } = string.Empty;
   
    }
}