using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        private readonly ICompanyManagerRepository _companyManagerRepository;
        private readonly IHttpContextAccessor _httpAccessor;

        public BranchService(IBranchRepository branchRepository, ICompanyRepository companyRepository, ICompanyManagerRepository companyManagerRepository, IHttpContextAccessor httpAccessor)
        {
            _branchRepository = branchRepository;
            _companyRepository = companyRepository;
            _companyManagerRepository = companyManagerRepository;
            _httpAccessor = httpAccessor;
        }

        public BaseResponse<BranchDto> Create(CreateBranchRequestModel model)
        {
            var user = _httpAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var companyManager = _companyManagerRepository.Get(a => a.UserId == user);
            // var company = _companyRepository.Get(companyId);
            var branchExist = _branchRepository.Get(a => a.Email == model.Email);
            if (branchExist == null)
            {
                Branch branch = new Branch();
                branch.CompanyId = companyManager.CompanyId;
                branch.Name = model.Name;
                branch.Address = model.Address;
                branch.Email = model.Email;
                branch.PhoneNumber = model.PhoneNumber;

                _branchRepository.Create(branch);
                _branchRepository.Save();
                return new BaseResponse<BranchDto>
                {
                    Message = "Successful",
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
                branch.Name = company.Name + " Headquarters";
                branch.Address = model.Address;
                branch.Email = model.Email;
                branch.PhoneNumber = model.PhoneNumber;

                _branchRepository.Create(branch);
                _branchRepository.Save();

                return new BaseResponse<BranchDto>
                {
                    Message = "Successful",
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
                Message = "Successful",
                Status = true
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
            // return null;
            var branch = _branchRepository.Get(a => a.Id == id);
            if (branch is not null)
            {
                branch.Name = model.Name;
                branch.Address = model.Address;
                branch.PhoneNumber = model.PhoneNumber;
                return new BaseResponse<BranchDto>
                {
                    Message = "Updated successfully",
                    Status = true,
                    Data = new BranchDto
                    {
                        Id = branch.Id,
                        Address = branch.Address,
                        CompanyId = branch.CompanyId,
                        Email = branch.Email,
                        Name = branch.Name,
                        PhoneNumber = branch.PhoneNumber
                    }
                };
            }

            return new BaseResponse<BranchDto>
            {
                Message = "Unable to Update",
                Status = false,
                
            };
        }
    }
}
