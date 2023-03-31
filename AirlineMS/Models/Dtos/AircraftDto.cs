using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AirlineMS.Models.Entities;

namespace AirlineMS.Models.Dtos
{
    public class AircraftDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string EngineNumber { get; set; }
        public int Capacity { get; set; }
        public string CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection<FlightDto> Flights = new HashSet<FlightDto>();
    }
    public class CreateAircraftRequestModel
    {
        [Required]
        [MinLength(5, ErrorMessage = "your name must not less than five character"), MaxLength(15, ErrorMessage = " your name must not greater than fifteen character")]
        public string Name { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 5)]
        public string EngineNumber { get; set; }
        [Required]
        public int Capacity { get; set; }

    }
    public class UpdateAircraftRequestModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string EngineNumber { get; set; }
        [Required]
        public int Capacity { get; set; }

    }
}