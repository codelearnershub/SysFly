using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirlineMS.Models.Dtos;
using AirlineMS.Models.Entities;
using AirlineMS.Repositories.Interfaces;
using AirlineMS.Services.Interfaces;
using static AirlineMS.Models.Dtos.CompanyManagerDto;

namespace AirlineMS.Services.Implementations
{
     public class CompanyManagerService : ICompanyManagerService
    {
        private readonly ICompanyManagerRepository _companyManagerRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
    
        public CompanyManagerService(ICompanyManagerRepository companyManagerRepository, IWebHostEnvironment webHostEnvironment)
        {
                _companyManagerRepository = companyManagerRepository;
                _webHostEnvironment = webHostEnvironment;
        }

        public BaseResponse<CompanyManagerDto> Create(CreateCompanyManagerRequestModel model)
        {
            var companyManagerExist = _companyManagerRepository.Get(a => a.User.Email == model.Email);
            if (companyManagerExist == null)
            {
                CompanyManager companyManager = new CompanyManager();
                companyManager.User.FirstName = model.FirstName;
                companyManager.User.LastName = model.LastName;
                companyManager.User.Email = model.Email;
                companyManager.User.Password = model.Password;
                companyManager.User.PhoneNumber = model.PhoneNumber;
                
                _companyManagerRepository.Create(companyManager);
                _companyManagerRepository.Save();
                return new BaseResponse<CompanyManagerDto>
                {
                    Message = "CompanyManager successfully created",
                    Status = true,
                    Data = new CompanyManagerDto
                    {
                        Id = companyManager.Id,
                        CompanyId = companyManager.CompanyId,
                        FirstName = companyManager.User.FirstName,
                        LastName = companyManager.User.LastName,
                        Email = companyManager.User.Email,
                        PhoneNumber = companyManager.User.PhoneNumber,
                    }
                };
            }
            return new BaseResponse<CompanyManagerDto>
            {
                Message = "invalid details",
                Status = false,
            };

        }

            public BaseResponse<CompanyManagerDto> Get(string id)
            {
                var companyManager = _companyManagerRepository.Get(id);
                if (companyManager is not null)
                {
                    return new BaseResponse<CompanyManagerDto>
                    {
                        Message = "CompanyManager found",
                        Status = true,
                        Data = new CompanyManagerDto
                        {
                            Id = companyManager.Id,
                            CompanyId = companyManager.CompanyId,
                            FirstName = companyManager.User.FirstName,
                            LastName = companyManager.User.LastName,
                            Email = companyManager.User.Email,
                            PhoneNumber = companyManager.User.PhoneNumber,
                        }
                    };
                }
                return new BaseResponse<CompanyManagerDto>
                {
                    Message = "invalid details",
                    Status = false,
                };
            }
        
        

        public BaseResponse<CompanyManagerDto> Delete(string id)
        {
             var objExists = _companyManagerRepository.Get(a => a.Id == id);
                if (objExists != null)
                {
                objExists.IsDeleted = true;
                _companyManagerRepository.Update(objExists);
                _companyManagerRepository.Save();
                
                    return new BaseResponse<CompanyManagerDto>{
                        Message = "successful",
                        Status = true
                    };
                }
                return new BaseResponse<CompanyManagerDto>
                {
                        Message = "CompanyManager already exists",
                        Status = false
                };
        }

       

        public BaseResponse<IEnumerable<CompanyManagerDto>> GetAll()
        {
            var companyManagers = _companyManagerRepository.GetAll();
            if (companyManagers is not null)
            {
                return new BaseResponse<IEnumerable<CompanyManagerDto>>
                {
                    Message = "Successful",
                    Status = true,
                    Data = companyManagers.Select(s => new CompanyManagerDto
                    {
                        Id = s.Id,
                        CompanyId = s.CompanyId,
                        FirstName = s.User.FirstName,
                        LastName = s.User.LastName,
                        Email = s.User.Email,
                        PhoneNumber = s.User.PhoneNumber,
                    })
                };
            }
            return new BaseResponse<IEnumerable<CompanyManagerDto>>
            {
                Message = "Not successful",
                Status = false,
            };
        }

        public BaseResponse<CompanyManagerDto> GetCompanyManagerByCompanyId(string companyId)
        {
            var companyManager = _companyManagerRepository.Get(a => a.CompanyId == companyId);
                if (companyManager is not null)
                {
                    return new BaseResponse<CompanyManagerDto>
                    {
                        Message = "companyManager found successfully",
                        Status = true,
                        Data = new CompanyManagerDto
                        {
                            Id = companyManager.Id,
                            CompanyId = companyManager.CompanyId,
                            FirstName = companyManager.User.FirstName,
                            LastName = companyManager.User.LastName,
                            Email = companyManager.User.Email,
                            PhoneNumber = companyManager.User.PhoneNumber,
                        }
                    };

                }
            
                return new BaseResponse<CompanyManagerDto>
                {
                    Message = "Not found",
                    Status = false,
                };
        }

        public BaseResponse<CompanyManagerDto> GetCompanyManagerByEmail(string email)
        {
            var companyManager = _companyManagerRepository.Get(a => a.User.Email == email);
                if (companyManager is not null)
                {
                    return new BaseResponse<CompanyManagerDto>
                    {
                        Message = "companyManager found successfully",
                        Status = true,
                        Data = new CompanyManagerDto
                        {
                            Id = companyManager.Id,
                            CompanyId = companyManager.CompanyId,
                            FirstName = companyManager.User.FirstName,
                            LastName = companyManager.User.LastName,
                            Email = companyManager.User.Email,
                            PhoneNumber = companyManager.User.PhoneNumber,
                        }
                    };

                }
            
                return new BaseResponse<CompanyManagerDto>
                {
                    Message = "Not found",
                    Status = false,
                };
        }

        public BaseResponse<CompanyManagerDto> Update(string id, UpdateCompanyManagerRequestModel model)
        {
           var companyManager = _companyManagerRepository.Get(id);
                if (companyManager is not null)
                {
                    companyManager.UserId = model.FirstName;
                    companyManager.User.LastName = model.LastName;
                    companyManager.User.PhoneNumber = model.PhoneNumber;
                    _companyManagerRepository.Update(companyManager);
                    _companyManagerRepository.Save();
                    return new BaseResponse<CompanyManagerDto>
                    {
                        Message = "Updated successfully",
                        Status = true,
                        Data = new CompanyManagerDto
                        {
                            FirstName = companyManager.User.FirstName,
                            LastName = companyManager.User.LastName,
                            PhoneNumber = companyManager.User.PhoneNumber,
                        }
                    };
                }
                return new BaseResponse<CompanyManagerDto>
                {
                    Message = "Not updated successfully",
                    Status = false,
                };
        }
    }
}
