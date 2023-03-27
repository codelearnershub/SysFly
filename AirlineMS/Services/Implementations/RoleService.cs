using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirlineMS.Models.Dtos;
using AirlineMS.Models.Entities;
using AirlineMS.Repositories.Implementations;
using AirlineMS.Services.Interfaces;

namespace AirlineMS.Services.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly RoleRepository _roleRepository;
        public RoleService(RoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public BaseResponse<RoleDto> Create(CreateRoleRequestModel model)
        {
            var roleExist = _roleRepository.Get(a => a.RoleName == model.RoleName);
            if (roleExist == null)
            {
                Role role = new Role();
                role.RoleName = model.RoleName;
                role.Description = model.Description;

                _roleRepository.Create(role);
                _roleRepository.Save();

                return new BaseResponse<RoleDto>
                {
                    Message = "Succcessful",
                    Status = true,
                    Data = new RoleDto
                    {
                        Id = role.Id,
                        RoleName = role.RoleName,
                        Description = role.Description,
                    }
                };
            }
            return new BaseResponse<RoleDto>
            {
                Message = "Already Exists",
                Status = false
            };
        }

      
        public BaseResponse<IEnumerable<RoleDto>> GetAllRolesOfAUser(string UserId)
        {
            throw new NotImplementedException();
        }

        

        public BaseResponse<RoleDto> GetRoleByRoleName(string roleName)
        {
            throw new NotImplementedException();
        }

        public BaseResponse<RoleDto> Update(string id, UpdateRoleRequestModel model)
        {
            throw new NotImplementedException();
        }
    }
}