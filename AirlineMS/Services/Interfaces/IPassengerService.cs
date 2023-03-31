
using AirlineMS.Models.Dtos;

namespace AirlineMS.Services.Interfaces
{
    public interface IPassengerService
    {
        BaseResponse<PassengerDto> Create(CreatePassengerRequestModel model);
        BaseResponse<PassengerDto> Update(string passengerId, UpdatePassengerRequestModel model);
        BaseResponse<PassengerDto> Get(string passengerId);
        BaseResponse<IEnumerable<PassengerDto>> GetAll();
        BaseResponse<IEnumerable<PassengerDto>> GetPassengersByFlightId(string flightId);
    }
}