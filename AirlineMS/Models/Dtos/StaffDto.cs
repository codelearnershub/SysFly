using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirlineMS.Models.Entities;

namespace AirlineMS.Models.Dtos
{
    public class StaffDto
    {
        public string Id{get;set;}
        public string UserId{get;set;}
        public string BranchId{get;set;}
        public User user{get;set;}

    }

     public class CreateStaffRequestModel
    {
        public string FirsttName{ get;set;}
        public string LastName{ get;set;}
        public string PhoneNumber{ get;set;}
        public string Email{ get;set;}
        public string Password{ get;set;}
    }

    public class UpdateStaffRequestModel
    {
        public string FirsttName{ get;set;}
        public string LastName{ get;set;}
        public string PhoneNumber{ get;set;}
    }
}