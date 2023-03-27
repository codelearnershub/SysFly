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
        [Required]
        [Range(5,15, ErrorMessage = "Firstname should not be less than 5 letters and more than 15 letters")]
        public string FirsttName { get; set; }
        [Required]
        [Range(5,15, ErrorMessage = "Lastname should not be less than 5 letters and more than 15 letters")]
        public string LastName { get; set; }
        [MaxLength(11, ErrorMessage = "PhoneNumber should not be more than 11 numbers")]
        [Required]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }

    public class UpdateStaffRequestModel
    {
        public string FirsttName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}