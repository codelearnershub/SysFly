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
     public class CompanyManagerService : ICompanyManagerService
    {
        private readonly ICompanyManagerRepository _companyManagerRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CompanyManagerService(ICompanyManagerRepository companyManagerRepository, IRoleRepository roleRepository, IUserRepository userRepository, IWebHostEnvironment webHostEnvironment)
        {
            _companyManagerRepository = companyManagerRepository;
            _roleRepository = roleRepository;
            _userRepository = userRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public BaseResponse<CompanyManagerDto> Create(string companyId, CreateCompanyManagerRequestModel model)
        {
            var userExist = _userRepository.Get(a => a.Email == model.Email);
            if (userExist == null)
            {

                var PhoneNumberExist = _userRepository.Get(a => a.PhoneNumber == model.PhoneNumber);
                if(PhoneNumberExist != null)
                {
                    return new BaseResponse<CompanyManagerDto>
                    {
                        Message = "PhoneNumber already used",
                        Status = false,
                    };
                }

                User user = new User{
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.Password,
                    PhoneNumber = model.PhoneNumber,
                };
                

                var role = _roleRepository.Get(r => r.Name == "Company Manager");
                
                var userRole = new UserRole{
                    UserId = user.Id,
                    RoleId = role.Id,
                    Role = role,
                    User = user,
                };

                user.UserRoles.Add(userRole);
                

                CompanyManager companyManager = new CompanyManager();
                companyManager.UserId = user.Id;
                companyManager.CompanyId = companyId;
                companyManager.EmploymentNumber = GenerateEmploymentNumber();
            

                _userRepository.Create(user);
                
                _companyManagerRepository.Create(companyManager);
                _companyManagerRepository.Save();

                

                return new BaseResponse<CompanyManagerDto>
                {
                    Message = "Successful",
                    Status = true,
                    Data = new CompanyManagerDto
                    {
                        Id = companyManager.Id,
                        CompanyId = companyManager.CompanyId,
                        UserId = companyManager.UserId
                    }
                };
            }
            return new BaseResponse<CompanyManagerDto>
            {
                Message = "Manager Already exist",
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
                        Message = "Successful",
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
        
        

        public BaseResponse<CompanyManagerDto> Delete(string id)
        {
             var objExists = _companyManagerRepository.Get(a => a.Id == id);
            if (objExists != null)
            {
                objExists.IsDeleted = true;
                _companyManagerRepository.Update(objExists);
                _companyManagerRepository.Save();
            
                return new BaseResponse<CompanyManagerDto>{
                    Message = "Successful",
                    Status = true
                };
            }
            return new BaseResponse<CompanyManagerDto>
            {
                Message = "Manager not found",
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
                    Data = companyManagers.Select(m => new CompanyManagerDto
                    {
                        Id = m.Id,
                        CompanyId = m.CompanyId,
                        FirstName = m.User.FirstName,
                        LastName = m.User.LastName,
                        Email = m.User.Email,
                        PhoneNumber = m.User.PhoneNumber,
                    })
                };
            }
            return new BaseResponse<IEnumerable<CompanyManagerDto>>
            {
                Message = "Not found",
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
                        Message = "Successful",
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
                        Message = "Successful",
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
                        Message = "Successfully",
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
                    Message = "Not found",
                    Status = false,
                };
        }
        private string GenerateEmploymentNumber(){
            var staffs = _companyManagerRepository.GetAll();
            return $"MNG/0000{staffs.Count() + 1}";
        }
    }
}
