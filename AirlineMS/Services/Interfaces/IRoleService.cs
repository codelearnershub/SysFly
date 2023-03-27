using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirlineMS.Models.Dtos;

namespace AirlineMS.Services.Interfaces
{
    public interface IRoleService

    {
        BaseResponse<RoleDto> Create(CreateRoleRequestModel model);
        BaseResponse<RoleDto> Update(string id, UpdateRoleRequestModel model);
        BaseResponse<RoleDto> GetRoleByRoleName(string roleName);
        BaseResponse<IEnumerable<RoleDto>> GetAllRolesOfAUser(string UserId);
    }
}