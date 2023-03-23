using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineMS.Models.Entities
{
    public class Staff : BaseEntity
    {
        public int UserId {get ; set;}
        public int BranchId {get ; set;}


        public User user {get ; set;}
        
    }
}