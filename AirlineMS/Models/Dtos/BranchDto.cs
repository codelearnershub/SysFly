using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineMS.Models.Dtos
{
    public class BranchDto
    {
        public string Id {get; set;}
        public string Name {get; set;}
        public string CompanyId {get; set;}
        public string CompanyName {get; set;}
        public string PhoneNumber {get; set;}
        public string Email {get; set;}
        public string Address {get; set;}
        public List<StaffDto> Staffs {get; set;}
    }

    public class CreateBranchRequestModel
    {
        [MinLength(5, ErrorMessage = "your name must not less than five character"), MaxLength(15,ErrorMessage = " your name must not greater than fifteen character")]
        public string Name {get; set;}
        [MaxLength(11, ErrorMessage = " Enter a valid phone number")]
        public string PhoneNumber {get; set;}
         [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",
        ErrorMessage = "Please enter a valid email address")]
        public string Email {get; set;}
        [Required]
        public string Address {get; set;}
    }

    public class UpDateBranchRequestModel
    {
        [MinLength(5, ErrorMessage = "your name must not less than five character"), MaxLength(15,ErrorMessage = " your name must not greater than fifteen character")]
        public string Name {get; set;}
        [MaxLength(11, ErrorMessage = " Enter a valid phone number")]
        public string PhoneNumber {get; set;}
        [Required]
        public string Address {get; set;}
    }
}