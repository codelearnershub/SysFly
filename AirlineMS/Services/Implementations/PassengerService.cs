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
        private readonly IUserRepository _userRepository;
        public PassengerService(IPassengerRepository passengerRepository, IUserRepository userRepository)
        {
            _passengerRepository = passengerRepository;
            _userRepository = userRepository;
        }
        public BaseResponse<PassengerDto> Create(CreatePassengerRequestModel model)
        {
            var userExist = _userRepository.Get(a => a.Email == model.Email);
            if (userExist == null)
            {
                /* Passenger passenger = new Passenger();
                passenger.User.FirstName = model.FirstName;
                passenger.User.LastName = model.LastName;
                passenger.User.Email = model.Email;
                passenger.User.Password = model.Password;
                passenger.User.PhoneNumber = model.PhoneNumber;
                _passengerRepository.Create(passenger);
                _passengerRepository.Save(); */
                var PhoneNumberExist = _userRepository.Get(a => a.PhoneNumber == model.PhoneNumber);
                if(PhoneNumberExist != null)
                {
                    return new BaseResponse<PassengerDto>
                    {
                        Message = "PhoneNumber already used",
                        Status = false,
                    };
                }

                User user = new User();
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.Password = model.Password;
                user.PhoneNumber = model.PhoneNumber;
                _userRepository.Create(user);
                _userRepository.Save();

                Passenger passenger = new Passenger();
                passenger.UserId = user.Id;
                _passengerRepository.Create(passenger);
                _passengerRepository.Save();

                return new BaseResponse<PassengerDto>
                {
                    Message = "Successfully",
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
                Message = "Already exist",
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
                Message = "Not found",
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
                    Message = "Successful",
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
                    Message = "Successful",
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
                Message = "Not found",
                Status = false,
            };
        }

        
    }
}