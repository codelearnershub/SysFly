using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineMS.Models.Entities
{
    public class PassengerFlight
    {
        public string TicketNumber{get; set;}
        public string PassengerId{get; set;}
        public Passenger Passenger{get; set;}
        public string FlightId{get; set;}
        public Flight Flight{get; set;}
    }
}