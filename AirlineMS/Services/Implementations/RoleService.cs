using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirlineMS.Models.Dtos;
using AirlineMS.Models.Entities;
using AirlineMS.Repositories.Implementations;
using AirlineMS.Repositories.Interfaces;
using AirlineMS.Services.Interfaces;

namespace AirlineMS.Services.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
        public RoleService(IRoleRepository roleRepository, IUserRepository userRepository)
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;
        }
        public BaseResponse<RoleDto> Create(CreateRoleRequestModel model)
        {
            var roleExist = _roleRepository.Get(a => a.Name == model.Name);
            if (roleExist == null)
            {
                Role role = new Role();
                role.Name = model.Name;
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
                        Name = role.Name,
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

        public BaseResponse<RoleDto> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public BaseResponse<RoleDto> Get(string id)
        {
            throw new NotImplementedException();
        }

        public BaseResponse<IEnumerable<RoleDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public BaseResponse<IEnumerable<UserDto>> GetAllUserOfARole(string roleId)      
        {

            var role = _roleRepository.Get(x => x.Id == roleId);
            if (role is null)
            {
                return new BaseResponse<IEnumerable<UserDto>>
                {
                    Message = "User does not Exist",
                    Status = false
                };
            }
    

            return new BaseResponse<IEnumerable<UserDto>>
            {
                
            };
        }

        public BaseResponse<IEnumerable<RoleDto>> GetRolesOfUser(string userId)
        {
            var user = _userRepository.Get(u => u.Id == userId);
            if(user == null)
            {
                return new BaseResponse<IEnumerable<RoleDto>>
                {
                    Message ="User does not exist",
                    Status = false
                };
            }
            List<RoleDto> userRoles = new List<RoleDto>();
            foreach (var item in user.UserRoles)
            {
                if (item.UserId == user.Id)
                {
                    userRoles.Add
                    (
                        new RoleDto{ Id = item.RoleId , Name = item.Role.Name}
                    );
                }
            }
            return new BaseResponse<IEnumerable<RoleDto>>
            {
                Message = "",
                Status = true,
                Data = userRoles
            };

        }

        public BaseResponse<RoleDto> Update(string id, UpdateRoleRequestModel model)
        {
            throw new NotImplementedException();
        }
    }
}