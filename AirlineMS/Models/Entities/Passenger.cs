using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineMS.Models.Entities
{
    public class Passenger : BaseEntity
    {
        public string UserId{get; set;}
        public User User{get; set;}
        public ICollection<PassengerFlight> PassengerFlights = new HashSet<PassengerFlight>();
    }
}