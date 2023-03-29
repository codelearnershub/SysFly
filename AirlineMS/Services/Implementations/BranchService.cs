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
    public class BranchService : IBranchService
    {
        private readonly BranchRepository _branchRepository;

        public BranchService(BranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public BaseResponse<BranchDto> Create(CreateBranchRequestModel model)
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

        public BaseResponse<IEnumerable<BranchDto>> GetAllBranchesOfACompany(string companyId)
        {
            var branch = _branchRepository.GetSelected(a => a.CompanyId == companyId);
            if(branch != null)
            {
                return new BaseResponse<IEnumerable<BranchDto>>
                {
                    Message = "Successful",
                    Status = true,
                    Data =  branch.Select(s => new BranchDto
                    {
                        Id = s.Id,
                        Name = s.Name,
                        PhoneNumber = s.PhoneNumber,
                        Email = s.Email,
                        Address = s.Address,
                        CompanyId = s.CompanyId,
                    })
                    
                };
            }
            return new BaseResponse<IEnumerable<BranchDto>>
            {
                Message = "Not found",
                Status = false,
            };
        }

        public BaseResponse<BranchDto> GetBranchByCompanyId(string companyId)
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
            var update = _branchRepository.Get(a => a.Id == id);
            if(update is not null)
            {
                update.Name = model.Name;
                update.Address = model.Address;
                update.PhoneNumber = model.PhoneNumber; 
                return new BaseResponse<BranchDto>
                {
                    Message = "Updated Successful",
                    Status = true,
                    Data = new BranchDto
                    {
                        Name = update.Name,
                        Address = update.Address,
                        PhoneNumber = update.PhoneNumber,
                    }
                };
            }
            return new BaseResponse<BranchDto>
            {
                Message = "Enable to Update",
                Status = false,
            };
        }
    }
}