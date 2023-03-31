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
        private readonly IBranchRepository _branchRepository;
        private readonly ICompanyRepository _companyRepository;

        public BranchService(IBranchRepository branchRepository, ICompanyRepository companyRepository)
        {
            _branchRepository = branchRepository;
            _companyRepository = companyRepository;
        }

      

        public BaseResponse<BranchDto> Create(string companyId, CreateBranchRequestModel model)
        {
            var company = _companyRepository.Get(companyId);
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

        public BaseResponse<BranchDto> CreateHeadquarters(string companyId, CreateHeadRequestModel model)
        {
            var company = _companyRepository.Get(companyId);
            var branchExist = _branchRepository.Get(a => a.Email == model.Email);
            if (branchExist == null)
            {
                Branch branch = new Branch();
                branch.CompanyId = companyId;
                branch.Name = company.Name + "Headquarters";
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

        public BaseResponse<BranchDto> Delete(string id)
        {
            var branch = _branchRepository.Get(id);
            if (branch is null)
            {
                return new BaseResponse<BranchDto>
                {
                    Message = "Not Found",
                    Status = false
                };
            }
            branch.IsDeleted = true;
            _branchRepository.Update(branch);
            _branchRepository.Save();
            return new BaseResponse<BranchDto>
            {
                Message = "Found",
                Status = false
            };
        }

       
       

        public BaseResponse<IEnumerable<BranchDto>> GetBranchesByCompanyId(string companyId)
        {
            var branches = _branchRepository.GetSelected(a => a.CompanyId == companyId);
            if (branches is not null)
            {
                return new BaseResponse<IEnumerable<BranchDto>>
                {
                    Message = "Successful",
                    Status = true,
                    Data = branches.Select(branch => new BranchDto
                    {
                        Id = branch.Id,
                        Name = branch.Name,
                        Address = branch.Address,
                        CompanyId = branch.CompanyId,
                        PhoneNumber = branch.PhoneNumber,
                        Email = branch.Email
                    }).ToList(),


                };
            }
            return new BaseResponse<IEnumerable<BranchDto>>
            {
                Message = "not found",
                Status = false,
            };

        }

        public BaseResponse<BranchDto> Update(string id, UpDateBranchRequestModel model)
        {
            return null;
            // var update = _branchRepository.Get(a => a.Id == id);
            // if (update is not null)
            // {
            //     update.Name = model.Name;
            //     update.Address = model.Address;
            //     update.PhoneNumber = model.PhoneNumber;
            //     return new BaseResponse<BranchDto>
            //     {
            //         Message = "Updated successfully",
            //         Status = true,
            //         Data = new BranchDto
            //         {
            //            PhoneNumber = branch.PhoneNumber,
            //            Address = branch.Address
                        
            //         }
            //     };
            // }

            // return new BaseResponse<BranchDto>
            // {
            //     Message = "Unable to Update",
            //     Status = false,
                
            // };
        }
    }
}
