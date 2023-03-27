using System;
using System.Collections.Generic;
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
        public string CompanyName { get; set; }
        public string CACRegistrationNum { get; set; }
        public IFormFile CACDocument { get; set; }
        public IFormFile Logo { get; set; }
        public string Email { get; set; }
        public string HQAddress { get; set; }
        public string HQPhoneNumber { get; set; }
    }

    public class UpdateCompanyRequestModel
    {
        public string Email { get; set; }
        public string HQAddress { get; set; }
        public string HQPhoneNumber { get; set; }
    }
}