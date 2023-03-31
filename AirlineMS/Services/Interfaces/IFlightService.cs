using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AirlineMS.Models.Dtos;
using AirlineMS.Models.Entities;

namespace AirlineMS.Services.Interfaces
{
    public interface IFlightService
    {
        BaseResponse<FlightDto> Create(CreateFlightRequestModel model);
        BaseResponse<FlightDto> Get(string id);
        BaseResponse<FlightDto> Update(string id, UpdateFlightRequestModel model);
        BaseResponse<FlightDto> Delete(string id);
        BaseResponse<IEnumerable<FlightDto>> GetAll();
    }
}