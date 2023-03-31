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
    public class AircraftService : IAircraftService
    {
        private readonly IAircraftRepository _aircraftRepository;
        private readonly ICompanyRepository _companyRepository;
        public AircraftService(IAircraftRepository aircraftRepository, ICompanyRepository companyRepository)
        {
            _aircraftRepository = aircraftRepository;
            _companyRepository = companyRepository;
        }
        public BaseResponse<AircraftDto> Create(string companyId, CreateAircraftRequestModel model)
        {
            var aircraftExists = _aircraftRepository.Get(a => a.EngineNumber == model.EngineNumber);
            if (aircraftExists == null)
            {
                Aircraft aircraft = new Aircraft();
                aircraft.Name = model.Name;
                aircraft.EngineNumber = model.EngineNumber;
                aircraft.Capacity = model.Capacity;

                _aircraftRepository.Create(aircraft);
                _aircraftRepository.Save();

                return new BaseResponse<AircraftDto>
                {
                    Message = "Succcessful",
                    Status = true,
                    Data = new AircraftDto
                    {
                        Id = aircraft.Id,
                        Name = aircraft.Name,
                        Capacity = aircraft.Capacity,
                        EngineNumber = aircraft.EngineNumber,
                        CompanyId = aircraft.CompanyId,
                        Company = aircraft.Company,
                    }
                };
            }
            return new BaseResponse<AircraftDto>
            {
                Message = "Already Exists",
                Status = false
            };
        }


        public BaseResponse<IEnumerable<AircraftDto>> GetAircraftsByCompanyId(string companyId)
        {
            var aircrafts = _aircraftRepository.GetSelected(a => a.CompanyId == companyId);
            if (aircrafts is not null)
            {
                return new BaseResponse<IEnumerable<AircraftDto>>
                {
                    Message = "Successful",
                    Status = true,
                    Data = aircrafts.Select(aircraft => new AircraftDto
                    {
                        Id = aircraft.Id,
                        Name = aircraft.Name,
                        Capacity = aircraft.Capacity,
                        EngineNumber = aircraft.EngineNumber,
                        CompanyId = aircraft.CompanyId,
                        Company = aircraft.Company
                    }).ToList(),


                };
            }
            return new BaseResponse<IEnumerable<AircraftDto>>
            {
                Message = "not found",
                Status = false,
            };
        }

        public BaseResponse<IEnumerable<AircraftDto>> GetAll()
        {
           var aircrafts = _aircraftRepository.GetAll();
            if (aircrafts == null)
            {
                return new BaseResponse<IEnumerable<AircraftDto>>{
                    Message = "No Aircraft found",
                    Status = false
                };
            }

            return new BaseResponse<IEnumerable<AircraftDto>>{
                Message = "Successful",
                Status = true,
                Data = aircrafts.Select(aircraft => new AircraftDto
                    {
                        Id = aircraft.Id,
                        Name = aircraft.Name,
                        Capacity = aircraft.Capacity,
                        EngineNumber = aircraft.EngineNumber,
                        CompanyId = aircraft.CompanyId,
                        Company = aircraft.Company
                    })
            };
        }

        public BaseResponse<AircraftDto> Update(string id, UpdateAircraftRequestModel model)
        {
             var update = _aircraftRepository.Get(a => a.Id == id);
            if (update is not null)
            {
                update.Name = model.Name;
                update.Capacity = model.Capacity;
                update.EngineNumber = model.EngineNumber;
                return new BaseResponse<AircraftDto>
                {
                    Message = "Updated Successful",
                    Status = true,
                    Data = new AircraftDto
                    {
                        Name = update.Name,
                        Capacity = update.Capacity,
                        EngineNumber = update.EngineNumber,
                    }
                };
            }
            return new BaseResponse<AircraftDto>
            {
                Message = "Update is not successful",
                Status = false,
            };

        }
         public BaseResponse<AircraftDto> GetAircraftByCompanyId(string companyId)
        {
            var aircraft = _aircraftRepository.Get(a => a.CompanyId == companyId);
            if (aircraft is not null)
            {
                return new BaseResponse<AircraftDto>
                {
                    Message = "Successful",
                    Status = true,
                    Data = new AircraftDto
                    {
                        Id = aircraft.Id,
                        Name = aircraft.Name,
                        Capacity = aircraft.Capacity,
                        EngineNumber = aircraft.EngineNumber,
                        CompanyId = aircraft.CompanyId,
                        Company = aircraft.Company
                    }

                };
            }
            return new BaseResponse<AircraftDto>
            {
                Message = "not found",
                Status = false,
            };

        }

        public BaseResponse<AircraftDto> Delete(string id, CreateAircraftRequestModel model)
        {
            var aircraftExists = _aircraftRepository.Get(d => d.Id == id);
             if (aircraftExists != null)
            {
               aircraftExists.IsDeleted = true;
              _aircraftRepository.Update(aircraftExists);
              _aircraftRepository.Save();
               
                return new BaseResponse<AircraftDto>{
                    Message = "successful",
                    Status = true
                };
            }
             return new BaseResponse<AircraftDto>{
                    Message = "Aircraft does not exists",
                    Status = false
                };
        }
    }
}