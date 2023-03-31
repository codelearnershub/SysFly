using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirlineMS.Models.Dtos;

namespace AirlineMS.Services.Interfaces
{
    public interface IUserService
    {
        BaseResponse<UserDto> Login(LoginUserRequestModel model);
        BaseResponse<UserDto> Get(string id);
        BaseResponse<List<UserDto>> GetAll();

    }
}