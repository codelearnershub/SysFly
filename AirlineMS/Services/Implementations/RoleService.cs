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

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
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
                    Message = "Successful",
                    Status = true,
                    Data = new RoleDto
                    {
                        Id = role.Id,
                        Name = role.Name,
                        Description = role.Description
                    }
                };
          }
          return new BaseResponse<RoleDto>
          {
            Message = "Alredy Exist",
            Status = false
          };

        }

        public BaseResponse<RoleDto> Delete(string id)
        {
          var role = _roleRepository.Get(id);
          if (role is null)
          {
            return new BaseResponse<RoleDto>
            {
                Message = "Not Found",
                Status = false
            };
          }
            role.IsDeleted = true;
            _roleRepository.Update(role);
            _roleRepository.Save();
            return new BaseResponse<RoleDto>
            {
                Message = "Found",
                Status = false
            };
       
        }

        public BaseResponse<RoleDto> Get(string id)
        {
            var role = _roleRepository.Get(id);
            if (role == null)
            {
                return new BaseResponse<RoleDto>
                {
                    Message = "Not found",
                    Status = true,
                };
            }
            return new BaseResponse<RoleDto>
            {
                Message = "Found",
                Status = false,
                Data = new RoleDto
                {
                    Id = role.Id,
                    Name = role.Name,
                    Description = role.Description
                }
            };

        }

        public BaseResponse<IEnumerable<RoleDto>> GetAll()
        {
            var role = _roleRepository.GetAll();
            if (role == null)
            {
                return new BaseResponse<IEnumerable<RoleDto>>
                {
                    Message = "Not found",
                    Status = false,
                };
            }
            return new BaseResponse<IEnumerable<RoleDto>>
            {
                Message = "Found",
                Status = true,
                Data = role.Select(c => new RoleDto{
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description
                })
            };
        }

        public BaseResponse<RoleDto> Update(string id, UpdateRoleRequestModel model)
        {
            var role = _roleRepository.Get(id);
            if (role is  null)
            {
                return new BaseResponse<RoleDto>
                {
                    Message = "Not found",
                    Status = false,
                };
            }
            _roleRepository.Create(role);
            _roleRepository.Save();
            return new BaseResponse<RoleDto>
            {
                Message = "Found",
                Status = true,
                Data = new RoleDto
                {
                    Id = role.Id,
                    Name = role.Name,
                    Description = role.Description
                }
            };
        }
    }
}