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
    public class BranchService : IBranchService
    {
        public readonly IBranchRepository _branchRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BranchService(IBranchRepository branchRepository, IWebHostEnvironment webHostEnvironment)
        {
            _branchRepository = branchRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public BaseResponse<BranchDto> Create(string agencyId, CreateBranchRequestModel model)
        {
            var branchExist = _branchRepository.Get(a => a.Email == model.Email);
            if (branchExist == null)
            {
                Branch branch = new Branch();
                branch.Name = model.Name;
                branch.Address = model.Address;
                branch.Email = model.Email;
                branch.PhoneNumber = model.PhoneNumber;

                _branchRepository.Create(branch);
                _branchRepository.Save();

                return new BaseResponse<BranchDto>
                {
                    Message = "Succcessful",
                    Status = true,
                    Data = new BranchDto
                    {
                        Id = branch.Id,
                        Name = branch.Name,
                        Address = branch.Address,
                        Email = branch.Email,
                        PhoneNumber = branch.PhoneNumber,
                        CompanyId = branch.CompanyId,

                    }
                };
            }
            return new BaseResponse<BranchDto>
            {
                Message = "ALready Exist",
                Status = false
            };

        }

        public BaseResponse<BranchDto> GetBranchesByCompanyId(string companyId)
        {
            var branch = _branchRepository.Get(a => a.CompanyId == companyId);
            if (branch is not  null)
            {
                return new BaseResponse<BranchDto>
                {
                   Message = "Successful",
                   Status = true,
                   Data =  new BranchDto
                   {
                     Id = branch.Id,
                     Name = branch.Name,
                     Address = branch.Address,
                     CompanyId = branch.CompanyId,
                     PhoneNumber = branch.PhoneNumber,
                     Email = branch.Email
                   }

                };
            }
            return new BaseResponse<BranchDto>
            {
              Message = "not found",
              Status = false,
            };
        }

        public BaseResponse<BranchDto> Update(string id, UpDateBranchRequestModel model)
        {
           var branch = _branchRepository.Get(a => a.Id == id);
            if (branch != null)
            {
                branch.PhoneNumber = model.PhoneNumber;
                branch.Address = model.Address;

                _branchRepository.Update(branch);
                _branchRepository.Save();
                return new BaseResponse<BranchDto>
                {
                    Message = "Updated successfully",
                    Status = true,
                    Data = new BranchDto
                    {
                       PhoneNumber = branch.PhoneNumber,
                       Address = branch.Address
                        
                    }
                };
            }

            return new BaseResponse<BranchDto>
            {
                Message = "Not successful",
                Status = false,
                
            };
        }
    }
}
