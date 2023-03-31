using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AirlineMS.Models.Dtos;
using AirlineMS.Models.Entities;
using AirlineMS.Repositories.Interfaces;
using AirlineMS.Services.Interfaces;

namespace AirlineMS.Services.Implementations
{
    public class FlightService : IFlightService

    {
        private readonly IFlightRepository _flightRepository;
        public FlightService(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public BaseResponse<FlightDto> Create(CreateFlightRequestModel model)
        {
            var flight = new Flight
            {
                Name = model.Name,
                Aircraft = model.Aircraft,
                AircraftId = model.AircraftId,
                Destination = model.Destination,
                TakeOffPoint = model.TakeOffPoint,
                TakeOffTime = model.TakeOffTime,
                LandingTime = model.LandingTime,
                Price = model.Price,
            };
            _flightRepository.Create(flight);
            _flightRepository.Save();
            return new BaseResponse<FlightDto>
            {
                Status = true,
                Message = "Successful",
                Data = new FlightDto
                {
                    Id = flight.Id,
                    Name = flight.Name,
                    TakeOffPoint = flight.TakeOffPoint,
                    Destination = flight.Destination,
                    TakeOffTime = flight.TakeOffTime,
                    LandingTime = flight.LandingTime,
                    FlightRef = flight.FlightRef,
                    PassengerFlights = flight.PassengerFlights,
                    Aircraft = flight.Aircraft,
                    AircraftId = flight.AircraftId,
                    Price = flight.Price
                }

            };
        }

        public BaseResponse<FlightDto> Delete(string id)
        {
            var flight = _flightRepository.Get(id);
            if (flight is not null)
            {
                flight.IsDeleted = true;
                return new BaseResponse<FlightDto>
                {
                    Message = "Successful",
                    Status  = true,
                    Data = new FlightDto
                    {
                        Id = flight.Id,
                        Name = flight.Name,
                        TakeOffPoint = flight.TakeOffPoint,
                        Destination = flight.Destination,
                        TakeOffTime = flight.TakeOffTime,
                        LandingTime = flight.LandingTime,
                        FlightRef = flight.FlightRef,
                        PassengerFlights = flight.PassengerFlights,
                        Aircraft = flight.Aircraft,
                        AircraftId = flight.AircraftId,
                        Price = flight.Price
                    }
                };
            }
            return new BaseResponse<FlightDto>
            {
                Message = "Fight not found",
                Status = false
            };
        }

        public BaseResponse<FlightDto> Get(string id)
        {
            var flight = _flightRepository.Get(id);
            if (flight is not null)
            {
                return new BaseResponse<FlightDto>
                {
                    Message = "Successful",
                    Status = true,
                    Data = new FlightDto
                    {
                        Id = flight.Id,
                        Name = flight.Name,
                        TakeOffPoint = flight.TakeOffPoint,
                        Destination = flight.Destination,
                        TakeOffTime = flight.TakeOffTime,
                        LandingTime = flight.LandingTime,
                        FlightRef = flight.FlightRef,
                        PassengerFlights = flight.PassengerFlights,
                        Aircraft = flight.Aircraft,
                        AircraftId = flight.AircraftId,
                        Price = flight.Price
                    }

                    
                };
            }
            return new BaseResponse<FlightDto>
            {
                Message = "Flight not found",
                Status = false
            };
        }

        public BaseResponse<IEnumerable<FlightDto>> GetAll()
        {
           var flight = _flightRepository.GetAll();
           if (flight != null)
           {
                return new BaseResponse<IEnumerable<FlightDto>>
                {
                    Message = "Successful",
                    Status = true,
                    Data = flight.Select( s => new FlightDto
                    {
                       Id = s.Id,
                        Name = s.Name,
                        TakeOffPoint = s.TakeOffPoint,
                        Destination = s.Destination,
                        TakeOffTime = s.TakeOffTime,
                        LandingTime = s.LandingTime,
                        FlightRef = s.FlightRef,
                        PassengerFlights = s.PassengerFlights,
                        Aircraft = s.Aircraft,
                        AircraftId = s.AircraftId,
                        Price = s.Price

                        
                    }).ToList()
                };
           }
           return new BaseResponse<IEnumerable<FlightDto>>
           {
                Message = "UnSuccessful",
                Status = false
           };
        }

        public BaseResponse<FlightDto> Update(string id, UpdateFlightRequestModel model)
        {
            var update = _flightRepository.Get(id);
            if (update is not null)
            {
                 var flight = _flightRepository.Update(update);
                 flight.Aircraft  = model.Aircraft;
                 flight.AircraftId = model.AircraftId;
                flight.Destination = model.Destination;
                flight.TakeOffPoint = model.TakeOffPoint;
                flight.LandingTime  = model.LandingTime;
                flight.TakeOffTime = model.TakeOffTime;
                return new BaseResponse<FlightDto>
                {
                    Message = "Successful",
                    Status = true,
                    Data = new FlightDto
                    {
                        Id = flight.Id,
                        Name = flight.Name,
                        TakeOffPoint = flight.TakeOffPoint,
                        Destination = flight.Destination,
                        TakeOffTime = flight.TakeOffTime,
                        LandingTime = flight.LandingTime,
                        FlightRef = flight.FlightRef,
                        PassengerFlights = flight.PassengerFlights,
                        Aircraft = flight.Aircraft,
                        AircraftId = flight.AircraftId,
                        Price = flight.Price
                    }
                };

            }
            return new BaseResponse<FlightDto>
            {
                Message = "Flght not found",
                Status  = false
            };

        }
    }
}