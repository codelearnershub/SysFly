using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirlineMS.Models.Dtos;

namespace AirlineMS.Services.Interfaces
{
    public interface IUserService
    {
        BaseResponse<UserDto> Create(CreateUserRequestModel model);
        BaseResponse<UserDto> Login(LoginUserRequestModel model);
        BaseResponse<UserDto> Update(string id, UpdateUserRequestModel model);

    }
}