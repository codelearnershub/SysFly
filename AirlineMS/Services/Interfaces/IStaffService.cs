using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirlineMS.Models.Dtos;

namespace AirlineMS.Services.Interfaces
{
    public interface IStaffService
    {
         BaseResponse<StaffDto> Create(string branchId, CreateStaffRequestModel model);
        BaseResponse<StaffDto> Update(string id, UpdateStaffRequestModel model);
        BaseResponse<StaffDto> Get(string id);
        BaseResponse<IEnumerable<StaffDto>> GetStaffsByCompanyId(string companyId);
        BaseResponse<IEnumerable<StaffDto>> GetStaffsByBranchId(string branchId);
        BaseResponse<IEnumerable<StaffDto>> GetAll();
    }
}