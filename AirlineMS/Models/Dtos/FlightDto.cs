using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirlineMS.Models.Entities;

namespace AirlineMS.Models.Dtos
{
    public class FlightDto
    {
        public string Id {get; set;}
        public string Name{get; set;}
        public string FlightRef{get; set;}
        public string Destination{get; set;}
        public string TakeOffPoint{get; set;}
        public DateTime TakeOffTime{get; set;}
        public DateTime LandingTime{get; set;}
        public double Price{get; set;}
        public string AircraftId{get; set;}
        public Aircraft Aircraft{get; set;}
        public ICollection<PassengerFlight> PassengerFlights = new HashSet<PassengerFlight>();
    }
    public class CreateFlightRequestModel
    {
        public string Name{get; set;}
        public string Destination{get; set;}
        public string TakeOffPoint{get; set;}
        public DateTime TakeOffTime{get; set;}
        public DateTime LandingTime{get; set;}
        public double Price{get; set;}
        public string AircraftId{get; set;}
        public Aircraft Aircraft{get; set;}
    }
    public class UpdateFlightRequestModel
    {
        public string Destination{get; set;}
        public string TakeOffPoint{get; set;}
        public DateTime TakeOffTime{get; set;}
        public DateTime LandingTime{get; set;}
        public double Price{get; set;}
        public string AircraftId{get; set;}
        public Aircraft Aircraft{get; set;}
    }
}