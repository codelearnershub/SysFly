using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirlineMS.Models.Dtos;

namespace AirlineMS.Services.Interfaces
{
    public interface ICompanyService
    {
        BaseResponse<CompanyDto> Create(CreateCompanyRequestModel model);
        BaseResponse<CompanyDto> Delete(string id);
        BaseResponse<CompanyDto> Get(string id);
        BaseResponse<IEnumerable<CompanyDto>> GetAll();
        BaseResponse<CompanyDto> Update(string id, UpdateCompanyRequestModel model);
    }
}