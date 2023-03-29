using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirlineMS.Models.Dtos;
using AirlineMS.Models.Entities;
using AirlineMS.Repositories.Implementations;
using AirlineMS.Services.Interfaces;

namespace AirlineMS.Services.Implementations
{
    public class StaffService : IStaffService
    {
        private readonly StaffRepository _staffRepository;
        public StaffService(StaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }
        public BaseResponse<StaffDto> Create(CreateStaffRequestModel model)
        {
            var staffExist = _staffRepository.Get(a => a.user.Email == model.Email);
            if (staffExist == null)
            {
                Staff staff = new Staff();
                staff.user.FirstName = model.FirstName;
                staff.user.LastName = model.LastName;
                staff.user.Email = model.Email;
                staff.user.Password = model.Password;
                staff.user.PhoneNumber = model.PhoneNumber;
                _staffRepository.Create(staff);
                _staffRepository.Save();

                return new BaseResponse<StaffDto>
                {
                    Message = "Succcessful",
                    Status = true,
                    Data = new StaffDto
                    {
                        Id = staff.Id,
                        BranchId = staff.BranchId,
                        FirstName = staff.user.FirstName,
                        LastName = staff.user.LastName,
                        Email = staff.user.Email,
                        PhoneNumber = staff.user.PhoneNumber,
                    }
                };
            }
            return new BaseResponse<StaffDto>
            {
                Message = "ALready Exist",
                Status = false
            };

        }

        public BaseResponse<StaffDto> Get(string id)
        {
            var staff = _staffRepository.Get(id);
            if (staff is not null)
            {
                return new BaseResponse<StaffDto>
                {
                    Message = "Staff successfully found",
                    Status = true,
                    Data = new StaffDto
                    {
                        Id = staff.Id,
                        BranchId = staff.BranchId,
                        FirstName = staff.user.FirstName,
                        LastName = staff.user.LastName,
                        PhoneNumber = staff.user.PhoneNumber,
                        Email = staff.user.Email,
                    }
                };
            }
            return new BaseResponse<StaffDto>
            {
                Message = "NOT Found",
                Status =false,
            };
        }

        public BaseResponse<IEnumerable<StaffDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public BaseResponse<IEnumerable<StaffDto>> GetAllStaffs(string branchId)
        {
            var check = _staffRepository.GetSelected(a => a.BranchId == branchId);
            if (check is not null)
            {
                return new BaseResponse<IEnumerable<StaffDto>>
                {
                    Message = "Successfull",
                    Status = true,
                    Data = check.Select(s => new StaffDto
                    {
                        Id = s.Id,
                        BranchId = s.BranchId,
                        FirstName = s.user.FirstName,
                        LastName = s.user.LastName,
                        Email = s.user.Email,
                        PhoneNumber = s.user.PhoneNumber,
                    })
                };
            }
            return new BaseResponse<IEnumerable<StaffDto>>
            {
                Message = "Not successful",
                Status = false,
            };


        }

        public BaseResponse<StaffDto> GetStaffByBranchId(string branchId)
        {
            var staff = _staffRepository.Get(a => a.BranchId == branchId);
            if (staff != null)
            {

                return new BaseResponse<StaffDto>
                {
                    Message = "Staff successfully found",
                    Status = true,
                    Data = new StaffDto
                    {
                        Id = staff.Id,
                        BranchId = staff.BranchId,
                        FirstName = staff.user.FirstName,
                        LastName = staff.user.LastName,
                        PhoneNumber = staff.user.PhoneNumber,
                        Email = staff.user.Email,
                    }
                };
            }
            return new BaseResponse<StaffDto>
            {
                Message = "Not found",
                Status = false,
            };
        }

        public BaseResponse<StaffDto> GetStaffsByBranchId(string branchId)
        {
            throw new NotImplementedException();
        }

        public BaseResponse<StaffDto> GetStaffsByCompanyId(string companyId)
        {
            throw new NotImplementedException();
        }

        public BaseResponse<StaffDto> Update(string id, UpdateStaffRequestModel model)
        {
            var staff = _staffRepository.Get(a => a.Id == id);
            if (staff is null)
            {
                return new BaseResponse<StaffDto>
                {
                    Message = "Not successful",
                    Status = false,
                };
            }

            staff.user.FirstName = model.FirstName;
            staff.user.LastName = model.LastName;
            staff.user.PhoneNumber = model.PhoneNumber;

            _staffRepository.Create(staff);
            _staffRepository.Save();

            return new BaseResponse<StaffDto>
            {
                Message = "Updated successfully",
                Status = true,
                Data = new StaffDto
                {
                    Id = staff.Id,
                    BranchId = staff.BranchId,
                    FirstName = staff.user.FirstName,
                    LastName = staff.user.LastName,
                    PhoneNumber = staff.user.PhoneNumber,
                    Email = staff.user.Email,
                }
            };
        }
    }
}