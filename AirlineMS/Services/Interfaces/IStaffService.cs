using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirlineMS.Models.Dtos;

namespace AirlineMS.Services.Interfaces
{
    public interface IStaffService
    {
         BaseResponse<StaffDto> Create(CreateStaffRequestModel model);
        BaseResponse<StaffDto> Update(string id, UpdateStaffRequestModel model);
        BaseResponse<StaffDto> Get(string id);
        BaseResponse<StaffDto> GetStaffsByCompanyId(string companyId);
        BaseResponse<StaffDto> GetStaffsByBranchId(string branchId);
        BaseResponse<IEnumerable<StaffDto>> GetAll();
    }
}