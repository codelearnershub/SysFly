using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirlineMS.Models.Dtos;
using static AirlineMS.Models.Dtos.CompanyManagerDto;

namespace AirlineMS.Services.Interfaces
{
    public interface ICompanyManagerService
    {
        BaseResponse<CompanyManagerDto> Create(string id, CreateCompanyManagerRequestModel model);
        BaseResponse<CompanyManagerDto> Update(string id, UpdateCompanyManagerRequestModel model);
        BaseResponse<CompanyManagerDto> Get(string id);
        BaseResponse<CompanyManagerDto> GetCompanyManagerByCompanyId(string companyId);
        BaseResponse<CompanyManagerDto> GetCompanyManagerByEmail(string email);
        BaseResponse<IEnumerable<CompanyManagerDto>> GetAll();
        BaseResponse<CompanyManagerDto> Delete(string id);


    }
}