using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirlineMS.Models.Dtos;

namespace AirlineMS.Services.Interfaces
{
    public interface IAirportService
    {
        BaseResponse<ArPortDto> Create(CreateAirportRequestModel model);
        BaseResponse<ArPortDto> Update(string id, UpdateAirportRequestModel model);
        BaseResponse<ArPortDto> Get(string id);
        BaseResponse<IEnumerable<ArPortDto>> GetAll();
        BaseResponse<ArPortDto> Delete(string id);
    }
}