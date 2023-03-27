using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AirlineMS.Models.Entities;

namespace AirlineMS.Models.Dtos
{
    public class StaffDto
    {
        public string Id { get; set; }
        public string BranchId { get; set; }
        public string FirsttName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }

    public class CreateStaffRequestModel
    {
        [MaxLength(50), MinLength(3)]
        public string FirstName{ get;set;}

        [Required]
        [MaxLength(50), MinLength(3)]
        public string LastName{ get;set;}
        [Required]
        [MaxLength(50), MinLength(10)]
        public string PhoneNumber{ get;set;}
        [Required]
        public string Email{ get;set;}
        [Required]
        public string Password{ get;set;}
    }

    public class UpdateStaffRequestModel
    {
        [Required]
        [MaxLength(50), MinLength(3)]

        public string FirstName{ get;set;}
        [Required]
        [MaxLength(50), MinLength(3)]

        public string LastName{ get;set;}
        
        [Required]
        [MaxLength(50), MinLength(10)]
        public string PhoneNumber{ get;set;}
    }
}