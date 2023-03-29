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
        public List<Branch> Branches {get; set;}
        public List<Staff> Staffs { get; set; }
    }
}