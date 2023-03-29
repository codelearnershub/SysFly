using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AirlineMS.Models.Dtos;
using AirlineMS.Models.Entities;
using AirlineMS.Repositories.Implementations;
using AirlineMS.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace AirlineMS.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public BaseResponse<UserDto> Get(string id)
        {
            var fetchs = _userRepository.Get(id);
            if (fetchs != null)
            {
                return new BaseResponse<UserDto>
                {
                    Message = "user found successfully",
                    Status = true,
                    Data = new UserDto
                    {
                        FirstName = fetchs.FirstName,
                        LastName = fetchs.LastName,
                        Email = fetchs.Email,
                        PhoneNumber = fetchs.PhoneNumber,
                        Id = fetchs.Id
                    }
                };
            }
            return new BaseResponse<UserDto>
            {
                Message = "User not found",
                Status = false,
            };
        }

        public BaseResponse<List<UserDto>> GetAll()
        {
            var getUsers = _userRepository.GetAll();
            if (getUsers != null)
            {
                return new BaseResponse<List<UserDto>>
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
            return new BaseResponse<List<UserDto>>
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
                Message = "Incorrect email of password",
                Status = false
            };
        }
    }
}