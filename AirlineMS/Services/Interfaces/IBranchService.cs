using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirlineMS.Models.Dtos;

namespace AirlineMS.Services.Interfaces
{
    public interface IBranchService
    {
        BaseResponse<BranchDto> Create(CreateBranchRequestModel model);
        BaseResponse<BranchDto> Update(string id, UpDateBranchRequestModel model);
        BaseResponse<BranchDto> GetBranchByCompanyId(string companyId);
        BaseResponse<IEnumerable<BranchDto>> GetAllBranchesOfACompany(string companyId);
    }
}