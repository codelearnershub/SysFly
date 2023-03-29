using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineMS.Models.Entities
{
    public class Staff : BaseEntity
    {
        public string UserId {get ; set;}
        public string BranchId {get ; set;}
        public string CompanyId{get; set;}
        public Company Company {get; set;}
        public User user {get ; set;}
        
    }
}