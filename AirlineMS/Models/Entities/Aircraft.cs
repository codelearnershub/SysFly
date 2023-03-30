using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineMS.Models.Entities
{
    public class Aircraft : BaseEntity
    {
        public string Name{get; set;}
        public string EngineNumber{get; set;}
        public int Capacity{get; set;}
        public string CompanyId{get; set;}
        public Company Company{get; set;}
        public ICollection<Flight> Flights = new HashSet<Flight>();
    }
}