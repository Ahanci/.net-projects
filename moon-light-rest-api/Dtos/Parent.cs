using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moon_light_rest_api.Dtos
{
    public class ParentCreateDto
    {
        public required string Name { get; set; }
        public required string PhoneNumber { get; set; }

        public string? Email { get; set; }       // E-posta adresi
    }
}