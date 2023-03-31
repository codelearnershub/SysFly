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
        public BaseResponse<ArPortDto> Create(CreateAirportRequestModel model)
        {
            var airport = _airportRepository.Get(x => x.Name == model.Name);
            if (airport is not null)
            {
                Airport airporte = new Airport();
                airport.Name = model.Name;
                airport.Address = model.Address;
                _airportRepository.Create(airporte);
                _airportRepository.Save();

                return new BaseResponse<ArPortDto>
                {
                    Message = "Successful",
                    Status = true,
                    Data = new ArPortDto
                    {
                        Id = airporte.Id,
                        Name = airporte.Name,
                        Address = airporte.Address

                    }
                };
            }
            return new BaseResponse<ArPortDto>{
                Message = "Existing Already",
                Status = false
            };

        }

        public BaseResponse<ArPortDto> Delete(string id)
        {
            var airport = _airportRepository.Get(x => x.Id == id);
            if (airport is not null)
            {
                airport.IsDeleted = true;
                _airportRepository.Update(airport);
                _airportRepository.Save();

                return new BaseResponse<ArPortDto>
                {
                        Message = "Remove Successful",
                        Status = true
                };
            }
            return new BaseResponse<ArPortDto>{
                Message = "Not Found",
                Status = false
            };
        }

        public BaseResponse<ArPortDto> Get(string id)
        {
            var airport = _airportRepository.Get(id);
            if (airport is not null)
            {
                return new BaseResponse<ArPortDto>
                {
                    Message = "Successful",
                    Status = true,
                    Data = new ArPortDto{
                        Id = airport.Id,
                        Name = airport.Name,
                        Address = airport.Address
                    }
                };

            }
            return new BaseResponse<ArPortDto>{
                Message = "Not Found"
            };
        }

        public BaseResponse<IEnumerable<ArPortDto>> GetAll()
        {
            var airport = _airportRepository.GetAll();
            if (airport is not null)
            {
                return new BaseResponse<IEnumerable<ArPortDto>>{
                    Message = "Successful",
                    Status = true
                };
            }
            return new BaseResponse<IEnumerable<ArPortDto>>{
                Message = "Not Found",
                Status = false,
                Data = airport.Select(c => new ArPortDto{
                    Id = c.Id,
                    Name = c.Name,
                    Address = c.Address

                })
            };
        }

        public BaseResponse<ArPortDto> Update(string id, UpdateAirportRequestModel model)
        {
            var airport = _airportRepository.Get(x => x.Id == id);
            if (airport is not null)
            {
                
                airport.Name = model.Name;
                airport.Address = model.Address;
                _airportRepository.Update(airport);
                _airportRepository.Save();

                return new BaseResponse<ArPortDto>
                {
                    Message = "Successful",
                    Status = true,
                    Data = new ArPortDto
                    {
                        Id = airport.Id,
                        Name = airport.Name,
                        Address = airport.Address

                    }
                };
            }
            return new BaseResponse<ArPortDto>{
                Message = "Not Found",
                Status = false
            };
        }
    }
}