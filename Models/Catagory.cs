using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_API.Models
{
    public class Catagory
{
    public Guid CatagoryId { get; set; }
    public string Name { get; set; } 
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}
}