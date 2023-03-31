using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirlineMS.Models.Dtos;

namespace AirlineMS.Services.Interfaces
{
    public interface IAircraftService
    {
        BaseResponse<AircraftDto> Create(string companyId, CreateAircraftRequestModel model);
        BaseResponse<AircraftDto> Update(string id, UpdateAircraftRequestModel model);
        BaseResponse<IEnumerable<AircraftDto>> GetAircraftsByCompanyId(string companyId);
        BaseResponse<IEnumerable<AircraftDto>> GetAll();
        BaseResponse<AircraftDto> Delete(string id, CreateAircraftRequestModel model);
        BaseResponse<AircraftDto> GetAircraftByCompanyId(string companyId);
    }
}