using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirlineMS.Models.Dtos;

namespace AirlineMS.Services.Interfaces
{
    public interface IBranchService
    {
        BaseResponse<BranchDto> Create(string companyId,CreateBranchRequestModel model);
        BaseResponse<BranchDto> CreateHeadquarters(string companyId,CreateHeadRequestModel model);
        BaseResponse<BranchDto> Update(string id, UpDateBranchRequestModel model);
        BaseResponse<IEnumerable<BranchDto>> GetBranchesByCompanyId(string companyId);
        BaseResponse<BranchDto> Delete(string id);
    }
}