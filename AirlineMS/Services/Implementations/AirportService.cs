using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirlineMS.Models.Dtos;
using AirlineMS.Models.Entities;
using AirlineMS.Repositories.Interfaces;
using AirlineMS.Services.Interfaces;

namespace AirlineMS.Services.Implementations
{
    public class AirportService : IAirportService
    {
        private readonly IAirportRepository _airportRepository;
        public AirportService(IAirportRepository airportRepository)
        {
            _airportRepository = airportRepository;
        }
        public BaseResponse<AirportDto> Create(CreateAirportRequestModel model)
        {
            var airportExit = _airportRepository.Get(x => x.Name == model.Name);
            if (airportExit is null)
            {
                Airport airport = new Airport();
                airport.Name = model.Name;
                airport.Address = model.Address;
                _airportRepository.Create(airport);
                _airportRepository.Save();

                return new BaseResponse<AirportDto>
                {
                    Message = "Successful",
                    Status = true,
                    Data = new AirportDto
                    {
                        Id = airport.Id,
                        Name = airport.Name,
                        Address = airport.Address

                    }
                };
            }
            return new BaseResponse<AirportDto>{
                Message = "Existing Already",
                Status = false
            };

        }

        public BaseResponse<AirportDto> Delete(string id)
        {
            var airport = _airportRepository.Get(x => x.Id == id);
            if (airport is not null)
            {
                airport.IsDeleted = true;
                _airportRepository.Update(airport);
                _airportRepository.Save();

                return new BaseResponse<AirportDto>
                {
                        Message = "Remove Successful",
                        Status = true
                };
            }
            return new BaseResponse<AirportDto>{
                Message = "Not Found",
                Status = false
            };
        }

        public BaseResponse<AirportDto> Get(string id)
        {
            var airport = _airportRepository.Get(id);
            if (airport is not null)
            {
                return new BaseResponse<AirportDto>
                {
                    Message = "Successful",
                    Status = true,
                    Data = new AirportDto{
                        Id = airport.Id,
                        Name = airport.Name,
                        Address = airport.Address
                    }
                };

            }
            return new BaseResponse<AirportDto>{
                Message = "Not Found",
                Status = false,
            };
        }

        public BaseResponse<IEnumerable<AirportDto>> GetAll()
        {
            var airport = _airportRepository.GetAll();
            if (airport is null)
            {
                return new BaseResponse<IEnumerable<AirportDto>>{
                    Message = "Not Found",
                    Status = false
                };
            }
            return new BaseResponse<IEnumerable<AirportDto>>{
                Message = "Successful",
                Status = true,
                Data = airport.Select(c => new AirportDto{
                    Id = c.Id,
                    Name = c.Name,
                    Address = c.Address

                })
            };
        }

        public BaseResponse<AirportDto> Update(string id, UpdateAirportRequestModel model)
        {
            var airport = _airportRepository.Get(x => x.Id == id);
            if (airport is not null)
            {
                
                airport.Name = model.Name;
                airport.Address = model.Address;
                _airportRepository.Update(airport);
                _airportRepository.Save();

                return new BaseResponse<AirportDto>
                {
                    Message = "Successful",
                    Status = true,
                    Data = new AirportDto
                    {
                        Id = airport.Id,
                        Name = airport.Name,
                        Address = airport.Address

                    }
                };
            }
            return new BaseResponse<AirportDto>{
                Message = "Not Found",
                Status = false
            };
        }
    }
}