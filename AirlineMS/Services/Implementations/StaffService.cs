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
        private readonly IStaffRepository _staffRepository;
        public StaffService(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        public BaseResponse<StaffDto> Create(CreateStaffRequestModel model)
        {
            var staffExist = _staffRepository.Get(a => a.User.Email == model.Email);
            if (staffExist == null)
            {
                Staff staff = new Staff();
                staff.User.FirstName = model.FirstName;
                staff.User.LastName = model.LastName;
                staff.User.Email = model.Email;
                staff.User.Password = model.Password;
                staff.User.PhoneNumber = model.PhoneNumber;
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
                    Message = "Staff found",
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
                Message = "Not successful",
                Status = false,
            };
        }

        public BaseResponse<StaffDto> GetStaffsByBranchId(string branchId)
        {
            var staff = _staffRepository.Get(a => a.BranchId == branchId);
            if (staff is not null)
            {
                return new BaseResponse<StaffDto>
                {
                    Message = "Staff found",
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

        public BaseResponse<StaffDto> GetStaffsByCompanyId(string companyId)
        {
            var staff = _staffRepository.Get(a => a.CompanyId == companyId);
            if (staff is not null)
            {
                return new BaseResponse<StaffDto>
                {
                    Message = "Staff found successfully",
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
                    Message = "Updated successfully",
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
                Message = "Not updated successfully",
                Status = false,
            };
        }
    }
}