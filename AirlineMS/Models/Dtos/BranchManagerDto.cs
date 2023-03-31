using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirlineMS.Models.Entities;

namespace AirlineMS.Models.Dtos
{
    public class BranchManagerDto
    {
        public string Id{get; set;}
        public string UserId{get; set;}
        public User User{get; set;}
        public string BranchId{get; set;}
        public Branch Branch{get; set;}
    }

    public class CreateBranchManagerRequestModel
    {
        public string UserId{get; set;}
        public string BranchId{get; set;}
    }
}