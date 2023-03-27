using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineMS.Models.Dtos
{
    public class CompanyDto
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string CompanyName { get; set; }
        public string CACRegistrationNum { get; set; }
        public string CACDocument { get; set; }
        public string Logo { get; set; }
        public string Email { get; set; }
        public string HQAddress { get; set; }
        public string HQPhoneNumber { get; set; }
        public List<BranchDto> Branches { get; set; }
        
    }

    public class CreateCompanyRequestModel
    {
        [Required]
        [StringLength(255, MinimumLength = 10)]
        public string CompanyName { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 5)]
        public string CACRegistrationNum { get; set; }
        [Required]
        public IFormFile CACDocument { get; set; }
        [Required]
        public IFormFile Logo { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 10)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 15)]
        public string HQAddress { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 11)]
        public string HQPhoneNumber { get; set; }
    }

    public class UpdateCompanyRequestModel
    {
        [Required, StringLength(50, MinimumLength = 10), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 10)]
        public string HQAddress { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 11)]
        [DataType(DataType.PhoneNumber)]
        public string HQPhoneNumber { get; set; }
    }
}