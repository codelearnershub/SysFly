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

        public BaseResponse<UserDto> Create(CreateUserRequestModel model)
        {
           var userExist = _userRepository.Get(a => a.Email == model.Email);
           if (userExist == null)
           {
                User user = new User();
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.Password = model.Password;
                user.PhoneNumber = model.PhoneNumber;
                _userRepository.Create(user);
                _userRepository.Save();

               return new BaseResponse<UserDto>
                {
                    Message = "Succcessful",
                    Status = true,
                    Data = new UserDto
                    {
                        Id = user.Id,
                        FirstName = user.FirstName,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        LastName = user.LastName,
                                               
                    }
                };
            }
            return new BaseResponse<UserDto>{
                Message = "ALready Exist",
                Status = false
            };
        }

        public BaseResponse<UserDto> Login(LoginUserRequestModel model)
        {
            var user =_userRepository.Get(a => a.Email == model.Email && a.Password == model.Password);
            if (user != null)
            {
                var userLogin =  new BaseResponse<UserDto> 
                {
                    Message = "Login Successful",
                    Status =true,
                    Data = new UserDto{
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        Id = user.Id
                    }
                };
            
            }
            return  new BaseResponse<UserDto>
            {
                Message = "Incorrect email of password",
                Status = false
            } ;
        }

        public BaseResponse<UserDto> Update(string id, UpdateUserRequestModel model)
        {
            User user = _userRepository.Get(id);
            if (user !=  null)
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.PhoneNumber  = model.PhoneNumber;
                return new BaseResponse<UserDto> 
                {
                    Message = "Update successful",
                    Status = true,
                    Data = new UserDto
                    {
                        LastName = user.LastName,
                        FirstName = user.FirstName,
                        PhoneNumber = user.PhoneNumber,
                        Email =user.Email,
                        Id = user.Id
                    }
                };
            }
            return new BaseResponse<UserDto>
            {
                Message = "Unable to Update",
                Status = false
            };
        }
    }
}