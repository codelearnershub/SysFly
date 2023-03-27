using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineMS.Models.Entities
{
    public class Company : BaseEntity
    {
        public string UserId { get; set; }
        public string CompanyName { get; set; }
        public string CACRegistrationNum { get; set; }
        public string CACDocument { get; set; }
        public string Logo { get; set; }
        public string Email { get; set; }
        public string HQAddress { get; set; }
        public string HQPhoneNumber { get; set; }
        public List<Staff> Staffs { get; set; }
    }
}