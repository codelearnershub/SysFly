using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AirlineMS.Models.Entities;

namespace AirlineMS.Models.Dtos
{
    public class CompanyManagerDto
    {
        public string Id { get; set; }
        public string UserId {get ; set;}
        public string CompanyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }  
    }

    public class CreateCompanyManagerRequestModel
    {
        [Required]
        [StringLength(25, MinimumLength = 10)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 10)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(11, ErrorMessage = " Enter a valid phone number")]
        public string PhoneNumber { get; set; }
        [Required]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        [Required]
        public string Password{ get;set;}
    }

    public class UpdateCompanyManagerRequestModel
    {
        [Required]
        [StringLength(25, MinimumLength = 10)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 10)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(11, ErrorMessage = " Enter a valid phone number")]
        public string PhoneNumber { get; set; }
    }
 }
