using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineMS.Models.Entities
{
    public class Staff : BaseEntity
    {
        public string EmploymentNumber{get; set;}
        public string UserId {get ; set;}
        public User User{get; set;}
        public string CompanyId{get; set;}
        public Company Company {get; set;}
        public string BranchId {get ; set;}
        public Branch Branch {get ; set;}
        
    }
}