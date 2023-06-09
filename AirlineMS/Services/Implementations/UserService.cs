using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AirlineMS.Models.Dtos;
using AirlineMS.Models.Entities;
using AirlineMS.Repositories.Implementations;
using AirlineMS.Repositories.Interfaces;
using AirlineMS.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace AirlineMS.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public BaseResponse<UserDto> Get(string id)
        {
            var user = _userRepository.Get(id);
            if (user != null)
            {
                return new BaseResponse<UserDto>
                {
                    Message = "Successfully",
                    Status = true,
                    Data = new UserDto
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        Id = user.Id
                    }
                };
            }
            return new BaseResponse<UserDto>
            {
                Message = "Not found",
                Status = false,
            };
        }

        public BaseResponse<IEnumerable<UserDto>> GetAll()
        {
            var getUsers = _userRepository.GetAll();
            if (getUsers != null)
            {
                return new BaseResponse<IEnumerable<UserDto>>
                {
                    Message = "Successful",
                    Status = true,
                    Data = getUsers.Select(g => new UserDto
                    {
                        FirstName = g.FirstName,
                        LastName = g.LastName,
                        Email = g.Email,
                        PhoneNumber = g.PhoneNumber,
                        Id = g.Id

                    }).ToList()
                };
            }
            return new BaseResponse<IEnumerable<UserDto>>
            {
                Message = "UnSuccessful",
                Status = false,

            };
        }

        public BaseResponse<UserDto> Login(LoginUserRequestModel model)
        {
            var user = _userRepository.Get(a => a.Email == model.Email && a.Password == model.Password);
            if (user != null)
            {
                var userLogin = new BaseResponse<UserDto>
                {
                    Message = "Login Successful",
                    Status = true,
                    Data = new UserDto
                    {
                        Id = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        Roles = user.UserRoles.Select(a => new RoleDto{
                            Id = a.Role.Id,
                            Name = a.Role.Name,
                            Description = a.Role.Description
                        }).ToList(),
                        
                    }
                };
                return userLogin;

            }
            return new BaseResponse<UserDto>
            {
                Message = "Incorrect email or password",
                Status = false
            };
        }
    }
}