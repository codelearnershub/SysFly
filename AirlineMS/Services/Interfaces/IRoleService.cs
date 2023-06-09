using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirlineMS.Models.Dtos;
using AirlineMS.Models.Entities;

namespace AirlineMS.Services.Interfaces
{
    public interface IRoleService
    {
        BaseResponse<RoleDto> Create(CreateRoleRequestModel model);
        BaseResponse<RoleDto> Update(string id, UpdateRoleRequestModel model);
        BaseResponse<RoleDto> Get(string id);
        BaseResponse<IEnumerable<RoleDto>> GetAll();
        BaseResponse<RoleDto> Delete(string id);
    }
}