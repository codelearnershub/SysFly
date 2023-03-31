using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirlineMS.Models.Dtos;
using AirlineMS.Models.Entities;
using AirlineMS.Repositories.Implementations;
using AirlineMS.Repositories.Interfaces;
using AirlineMS.Services.Interfaces;

namespace AirlineMS.Services.Implementations
{
    public class PassengerService : IPassengerService
    {
        private readonly IPassengerRepository _passengerRepository;
        private readonly IFlightRepository _flightRepository;
        public PassengerService(IPassengerRepository passengerRepository, IFlightRepository flightRepository)
        {
            _passengerRepository = passengerRepository;
            _flightRepository = flightRepository;
        }
        BaseResponse<PassengerDto> Create(CreatePassengerRequestModel model)
        {
            var passengerExist = _passengerRepository.Get(a => a.User.Email == model.Email);
            if (passengerExist == null)
            {
                Passenger passenger = new Passenger();
                passenger.User.FirstName = model.FirstName;
                passenger.User.LastName = model.LastName;
                passenger.User.Email = model.Email;
                passenger.User.Password = model.Password;
                passenger.User.PhoneNumber = model.PhoneNumber;
                _passengerRepository.Create(passenger);
                _passengerRepository.Save();
                return new BaseResponse<PassengerDto>
                {
                    Message = "Passenger created successfully",
                    Status = true,
                    Data = new PassengerDto
                    {
                        Id = passenger.Id,
                        FirstName = passenger.User.FirstName,
                        LastName = passenger.User.LastName,
                        Email = passenger.User.Email,
                        PhoneNumber = passenger.User.PhoneNumber,
                    }
                };
            }
            return new BaseResponse<PassengerDto>
            {
                Message = "invalid details",
                Status = false,
            };
        }

           public BaseResponse<IEnumerable<PassengerDto>> GetAll()
        {
            var passengers = _passengerRepository.GetAll();
            if (passengers is not null)
            {
                return new BaseResponse<IEnumerable<PassengerDto>>
                {
                    Message = "Successful",
                    Status = true,
                    Data = passengers.Select(s => new PassengerDto
                    {
                        Id = s.Id,
                        FirstName = s.User.FirstName,
                        LastName = s.User.LastName,
                        Email = s.User.Email,
                        PhoneNumber = s.User.PhoneNumber,
                        // Flight = new FlightDto
                        // {
                        //     Name = s.Name,

                        // }

                    })
                };
            }
            return new BaseResponse<IEnumerable<PassengerDto>>
            {
                Message = "Not successful",
                Status = false,
            };
        }

        public BaseResponse<PassengerDto> Get(string id)
        {
            var passenger = _passengerRepository.Get(id);
            if (passenger is not null)
            {
                return new BaseResponse<PassengerDto>
                {
                    Message = "passenger found",
                    Status = true,
                    Data = new PassengerDto
                    {
                        Id = passenger.Id,
                        FirstName = passenger.User.FirstName,
                        LastName = passenger.User.LastName,
                        Email = passenger.User.Email,
                        PhoneNumber = passenger.User.PhoneNumber,
                    }
                };
            }
            return new BaseResponse<PassengerDto>
            {
                Message = "invalid details",
                Status = false,
            };
        }

        public BaseResponse<IEnumerable<PassengerDto>> GetPassengersByFlightId(string flightId)
        {
            var passengers = _passengerRepository.GetAll();
            if (passengers is not null)
            {
                return new BaseResponse<IEnumerable<PassengerDto>>
                {
                    Message = "passenger found",
                    Status = true,
                    Data = passengers.Select(a => new PassengerDto
                    {
                        Id = a.Id,
                        FirstName = a.User.FirstName,
                        LastName = a.User.LastName,
                        Email = a.User.Email,
                        PhoneNumber = a.User.PhoneNumber,
                    }).ToList(),
                };
            }
            return new BaseResponse<IEnumerable<PassengerDto>>
            {
                Message = "Not found",
                Status = false,
            };
        }

        public BaseResponse<PassengerDto> Update(string id, UpdatePassengerRequestModel model)
        {
            var passenger = _passengerRepository.Get(id);
            if (passenger is not null)
            {
                passenger.User.FirstName = model.FirstName;
                passenger.User.LastName = model.LastName;
                passenger.User.PhoneNumber = model.PhoneNumber;
                _passengerRepository.Update(passenger);
                _passengerRepository.Save();
                return new BaseResponse<PassengerDto>
                {
                    Message = "Updated successfully",
                    Status = true,
                    Data = new PassengerDto
                    {
                        FirstName = passenger.User.FirstName,
                        LastName = passenger.User.LastName,
                        PhoneNumber = passenger.User.PhoneNumber,
                    }
                };
            }
            return new BaseResponse<PassengerDto>
            {
                Message = "Not updated successfully",
                Status = false,
            };
        }

        BaseResponse<PassengerDto> IPassengerService.Create(CreatePassengerRequestModel model)
        {
            throw new NotImplementedException();
        }
    }
}