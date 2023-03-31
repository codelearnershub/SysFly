using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineMS.Models.Dtos
{
    public class ArPortDto
    {
        public string Id {get ; set;}
        public string Name {get ; set;}
        public string Address {get ; set;}
    }

    public class CreateAirportRequestModel
    {
        [Required]
        [StringLength(255, MinimumLength = 10)]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
    }

    public class UpdateAirportRequestModel
    {
        [Required]
        [StringLength(255, MinimumLength = 10)]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
    }
}