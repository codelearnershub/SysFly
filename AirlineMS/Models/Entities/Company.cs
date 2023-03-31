using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineMS.Models.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public string CACRegistrationNum { get; set; }       
        public string CACDocument { get; set; }
        public string Logo { get; set; }
        public ICollection<Branch> Branches {get; set;} = new HashSet<Branch>();
        public ICollection<Staff> Staffs { get; set; } = new HashSet<Staff>();
        public ICollection<Aircraft> Aircrafts{get; set;} = new HashSet<Aircraft>();
    }
}