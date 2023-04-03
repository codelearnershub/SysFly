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
    public class StaffService : IStaffService
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IStaffRepository _staffRepository;
        private readonly IUserRepository _userRepository;

        public StaffService(IStaffRepository staffRepository, IUserRepository userRepository)
        {
            _staffRepository = staffRepository;
            _userRepository = userRepository;
        }

        public BaseResponse<StaffDto> Create(string branchId, CreateStaffRequestModel model)
        {
            var userExist = _userRepository.Get(a => a.Email == model.Email);
            if (userExist == null)
            {
                
                var PhoneNumberExist = _userRepository.Get(a => a.PhoneNumber == model.PhoneNumber);
                if(PhoneNumberExist != null)
                {
                    return new BaseResponse<StaffDto>
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
                    PhoneNumber = model.PhoneNumber
                };
                
                _userRepository.Create(user);
                _userRepository.Save();

                var branch = _branchRepository.Get(branchId);

                Staff staff = new Staff{
                    BranchId = branchId,
                    CompanyId = branch.CompanyId,
                    EmploymentNumber = GenerateEmploymentNumber(),
                    UserId = user.Id
                };
                _staffRepository.Create(staff);
                _staffRepository.Save();
                return new BaseResponse<StaffDto>
                {
                    Message = "Staff successfully created",
                    Status = true,
                    Data = new StaffDto
                    {
                        Id = staff.Id,
                        BranchId = staff.BranchId,
                        CompanyId = staff.CompanyId,
                        FirstName = staff.User.FirstName,
                        LastName = staff.User.LastName,
                        Email = staff.User.Email,
                        PhoneNumber = staff.User.PhoneNumber,
                    }
                };
            }
            return new BaseResponse<StaffDto>
            {
                Message = "invalid details",
                Status = false,
            };
        }

        public BaseResponse<StaffDto> Get(string id)
        {
            var staff = _staffRepository.Get(id);
            if (staff is not null)
            {
                return new BaseResponse<StaffDto>
                {
                    Message = "Successful",
                    Status = true,
                    Data = new StaffDto
                    {
                        Id = staff.Id,
                        BranchId = staff.BranchId,
                        CompanyId = staff.CompanyId,
                        FirstName = staff.User.FirstName,
                        LastName = staff.User.LastName,
                        Email = staff.User.Email,
                        PhoneNumber = staff.User.PhoneNumber,
                    }
                };
            }
            return new BaseResponse<StaffDto>
            {
                Message = "Not found",
                Status = false,
            };
        }

        public BaseResponse<IEnumerable<StaffDto>> GetAll()
        {
            var staffs = _staffRepository.GetAll();
            if (staffs is not null)
            {
                return new BaseResponse<IEnumerable<StaffDto>>
                {
                    Message = "Successful",
                    Status = true,
                    Data = staffs.Select(s => new StaffDto
                    {
                        Id = s.Id,
                        BranchId = s.BranchId,
                        CompanyId = s.CompanyId,
                        FirstName = s.User.FirstName,
                        LastName = s.User.LastName,
                        Email = s.User.Email,
                        PhoneNumber = s.User.PhoneNumber,
                    })
                };
            }
            return new BaseResponse<IEnumerable<StaffDto>>
            {
                Message = "Not found",
                Status = false,
            };
        }

        public BaseResponse<IEnumerable<StaffDto>> GetStaffsByBranchId(string branchId)
        {
            var staff = _staffRepository.GetSelected(a => a.BranchId == branchId);
            if (staff is not null)
            {
                return new BaseResponse<IEnumerable<StaffDto>>
                {
                    Message = "Successful",
                    Status = true,
                    Data = staff.Select(s => new StaffDto
                    {
                        Id = s.Id,
                        BranchId = s.BranchId,
                        CompanyId = s.CompanyId,
                        FirstName = s.User.FirstName,
                        LastName = s.User.LastName,
                        Email = s.User.Email,
                        PhoneNumber = s.User.PhoneNumber,
                    })
                };
            }
            return new BaseResponse<IEnumerable<StaffDto>>
            {
                Message = "Not found",
                Status = false,
            };
        }

        public BaseResponse<IEnumerable<StaffDto>> GetStaffsByCompanyId(string companyId)
        {
            var staff = _staffRepository.GetSelected(a => a.CompanyId == companyId);
            if (staff is not null)
            {
                return new BaseResponse<IEnumerable<StaffDto>>
                {
                    Message = "Successful",
                    Status = true,
                    Data = staff.Select(s => new StaffDto
                    {
                        Id = s.Id,
                        BranchId = s.BranchId,
                        CompanyId = s.CompanyId,
                        FirstName = s.User.FirstName,
                        LastName = s.User.LastName,
                        Email = s.User.Email,
                        PhoneNumber = s.User.PhoneNumber,
                    })
                };
            }
            return new BaseResponse<IEnumerable<StaffDto>>
            {
                Message = "Not found",
                Status = false,
            };
        }

        public BaseResponse<StaffDto> Update(string id, UpdateStaffRequestModel model)
        {
            var staff = _staffRepository.Get(id);
            if (staff is not null)
            {
                staff.User.FirstName = model.FirstName;
                staff.User.LastName = model.LastName;
                staff.User.PhoneNumber = model.PhoneNumber;
                _staffRepository.Update(staff);
                _staffRepository.Save();
                return new BaseResponse<StaffDto>
                {
                    Message = "Successful",
                    Status = true,
                    Data = new StaffDto
                    {
                        FirstName = staff.User.FirstName,
                        LastName = staff.User.LastName,
                        PhoneNumber = staff.User.PhoneNumber,
                    }
                };
            }
            return new BaseResponse<StaffDto>
            {
                Message = "Not found",
                Status = false,
            };
        }

        private string GenerateEmploymentNumber(){
            var staffs = _staffRepository.GetAll();
            return $"STF/0000{staffs.Count() + 1}";
        }
    }
}