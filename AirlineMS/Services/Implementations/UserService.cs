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
            throw new NotImplementedException();
        }

        public BaseResponse<List<UserDto>> GetAll()
        {
            throw new NotImplementedException();
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
    }
}