using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirlineMS.Models.Entities;

namespace AirlineMS.Models.Dtos
{
    public class UserDto
    {
        public string Id{get; set;}
        public string FirstName{ get;set;}
        public string LastName{ get;set;}
        public string PhoneNumber{ get;set;}
        public string Email{ get;set;}
        public List<UserRole> UserRoles{ get;set;}
    }
    public class CreateUserRequestModel
    {
        public string FirstName{ get;set;}
        public string LastName{ get;set;}
        public string PhoneNumber{ get;set;}
        public string Email{ get;set;}
        public string Password{ get;set;}  
    }
    public class UpdateUserRequestModel
    {
        public string FirstName{ get;set;}
        public string LastName{ get;set;}
        public string PhoneNumber{ get;set;}
    }
    public class LoginUserRequestModel
    {
        public string Email{ get;set;}
        public string Password{ get;set;} 
    }
}