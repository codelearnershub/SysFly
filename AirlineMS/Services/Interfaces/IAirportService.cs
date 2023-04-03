using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirlineMS.Models.Dtos;

namespace AirlineMS.Services.Interfaces
{
    public interface IAirportService
    {
        BaseResponse<AirportDto> Create(CreateAirportRequestModel model);
        BaseResponse<AirportDto> Update(string id, UpdateAirportRequestModel model);
        BaseResponse<AirportDto> Get(string id);
        BaseResponse<IEnumerable<AirportDto>> GetAll();
        BaseResponse<AirportDto> Delete(string id);
    }
}