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
            var staffExist =  _staffRepository.Get(a => a.user.Email == model.Email);
            if (staffExist == null)
            {
                Staff staff = new Staff();
                staff.user.Email =model.FirsttName;
                staff.user.LastName= model.LastName;
                staff.user.Email = model.Email;
                staff.user.Password= model.Password;
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
                      UserId= staff.UserId,
                      BranchId = staff.BranchId,
                      user = staff.user,
                    }
                };
            }
            return new BaseResponse<StaffDto>{
                Message = "ALready Exist",
                Status = false
            };

        }

        

        public BaseResponse<IEnumerable<StaffDto>> GetAllStaffs(string branchId)
        {
            throw new NotImplementedException();
        }

        public BaseResponse<StaffDto> GetStaffByBranchId(string branchId)
        {
            throw new NotImplementedException();
        }

      

        public BaseResponse<StaffDto> Update(string id, UpdateStaffRequestModel model)
        {
            throw new NotImplementedException();
        }
    }
}