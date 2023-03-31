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
    public class BranchManagerService : IBranchManagerService
    {
        private readonly IBranchManagerRepository _branchManagerRepository;
        private readonly IUserRepository _userRepository;

        public BranchManagerService(IBranchManagerRepository branchManagerRepository, IUserRepository userRepository)
        {
            _branchManagerRepository = branchManagerRepository;
            _userRepository = userRepository;
        }

        public BaseResponse<BranchManagerDto> Create(CreateBranchManagerRequestModel model)
        {
            var managerExist = _branchManagerRepository.Get(m => m.UserId == model.UserId);
            if(managerExist is not null)
            {
                return new BaseResponse<BranchManagerDto>{
                    Message = "Manager Already Exist!",
                    Status = false
                };
            }

            var newManager = new BranchManager{
                UserId = model.UserId,
                BranchId = model.BranchId
            };

            _branchManagerRepository.Create(newManager);
            _branchManagerRepository.Save();

            return new BaseResponse<BranchManagerDto>{
                Message = "Successful",
                Status = true,
                Data = new BranchManagerDto{
                    Id = newManager.Id,
                    UserId = newManager.UserId,
                    BranchId = newManager.BranchId,
                }
            };
        }

        public BaseResponse<BranchManagerDto> Get(string id)
        {
            var manager = _branchManagerRepository.Get(id);
            if (manager == null)
            {
                return new BaseResponse<BranchManagerDto>{
                    Message = "Manager does not Exist!",
                    Status = false
                };
            }

            return new BaseResponse<BranchManagerDto>{
                Message = "Successful",
                Status = true,
                Data = new BranchManagerDto{
                    Id = manager.Id,
                    UserId = manager.UserId,
                    BranchId = manager.BranchId,
                }
            };
        }

        public BaseResponse<BranchManagerDto> GetByEmail(string email)
        {
            var user = _userRepository.Get(u => u.Email == email && u.IsDeleted == false);
            if (user == null)
            {
                return new BaseResponse<BranchManagerDto>{
                    Message = "Manager does not Exist!",
                    Status = false
                };
            }

            var manager = _branchManagerRepository.Get(u => u.UserId == user.Id && u.IsDeleted == false);
            return new BaseResponse<BranchManagerDto>{
                Message = "Successful",
                Status = true,
                Data = new BranchManagerDto{
                    Id = manager.Id,
                    UserId = manager.UserId,
                    BranchId = manager.BranchId,
                }
            };
        }
    }
}