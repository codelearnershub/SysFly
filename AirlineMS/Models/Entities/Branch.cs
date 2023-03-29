using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineMS.Models.Entities
{
    public class Branch : BaseEntity
    {
        public string Name {get; set;}
        public string CompanyId {get; set;}
        public Company Company{get; set;}
        public string Email {get; set;}
        public string Address {get; set;}
        public string PhoneNumber {get; set;}
        public List<Staff> Staffs {get; set;}






    }
}