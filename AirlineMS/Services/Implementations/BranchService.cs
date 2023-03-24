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
            return new BaseResponse<BranchDto>{
                Message = "ALready Exist",
                Status = false
            };

        }

        public BaseResponse<IEnumerable<BranchDto>> GetAllBranchesOfACompany(string companyId)
        {
            throw new NotImplementedException();
        }

        public BaseResponse<BranchDto> GetBranchByCompanyId(string companyId)
        {
            throw new NotImplementedException();
        }

        public BaseResponse<BranchDto> Update(string id, UpDateBranchRequestModel model)
        {
            throw new NotImplementedException();
        }
    }
}