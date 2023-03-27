using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirlineMS.Models.Dtos;
using AirlineMS.Models.Entities;
using AirlineMS.Repositories.Interfaces;
using AirlineMS.Services.Interfaces;

namespace AirlineMS.Services.Implementations
{
    public class CompanyService : ICompanyService
    {
        private ICompanyRepository _companyRepository;
        private IWebHostEnvironment _webHostEnvironment;

        public CompanyService(ICompanyRepository companyRepository, IWebHostEnvironment webHostEnvironment)
        {
            _companyRepository = companyRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public BaseResponse<CompanyDto> Create(CreateCompanyRequestModel model)
        {
            var companyExist = _companyRepository.Get(c => c.Email == model.Email);
            if (companyExist is not null)
            {
                return new BaseResponse<CompanyDto>{
                    Message = "Company already exist",
                    Status = false
                };
            }

            var CACRegistrationNum = UploadFile(model.CACDocument);
            var Logo = UploadFile(model.Logo);

            var newCompany = new Company{
                CACDocument = CACRegistrationNum,
                CACRegistrationNum = model.CACRegistrationNum,
                CompanyName = model.CompanyName,
                Email = model.Email,
                HQAddress = model.HQAddress,
                Logo = Logo
            };

            _companyRepository.Create(newCompany);
            _companyRepository.Save();

            return new BaseResponse<CompanyDto>{
                Message = "Successful",
                Status = true,
                Data = new CompanyDto{
                    Id = newCompany.Id,
                    UserId = newCompany.UserId,
                    CompanyName = newCompany.CompanyName,
                    CACRegistrationNum = newCompany.CACRegistrationNum,
                    CACDocument = newCompany.CACDocument,
                    Logo = newCompany.Logo,
                    Email = newCompany.Email,
                    HQAddress = newCompany.HQAddress,
                    HQPhoneNumber = newCompany.HQPhoneNumber,
                    Branches = newCompany.Branches.Select(b => new BranchDto{
                        Id = b.Id,
                        Name = b.Name,
                        Address = b.Address,
                        Email = b.Email,
                        PhoneNumber = b.PhoneNumber,
                        CompanyId = b.CompanyId,
                    }).ToList()
                }
            };
        }

        public BaseResponse<CompanyDto> Update(string id, UpdateCompanyRequestModel model)
        {
            var company = _companyRepository.Get(c => c.Email == model.Email);
            if (company is null)
            {
                return new BaseResponse<CompanyDto>{
                    Message = "Company not found",
                    Status = false
                };
            }

    
            company.Email = model.Email;
            company.HQAddress = model.HQAddress;
            company.HQPhoneNumber = model.HQPhoneNumber;

            _companyRepository.Create(company);
            _companyRepository.Save();

            return new BaseResponse<CompanyDto>{
                Message = "Successful",
                Status = true,
                Data = new CompanyDto{
                    Id = company.Id,
                    UserId = company.UserId,
                    CompanyName = company.CompanyName,
                    CACRegistrationNum = company.CACRegistrationNum,
                    CACDocument = company.CACDocument,
                    Logo = company.Logo,
                    Email = company.Email,
                    HQAddress = company.HQAddress,
                    HQPhoneNumber = company.HQPhoneNumber,
                    Branches = company.Branches.Select(b => new BranchDto{
                        Id = b.Id,
                        Name = b.Name,
                        Address = b.Address,
                        Email = b.Email,
                        PhoneNumber = b.PhoneNumber,
                        CompanyId = b.CompanyId,
                    }).ToList()
                }
            };
        }


        private string UploadFile(IFormFile file)
        {
            var appUploadPath = Path.Combine(_webHostEnvironment.WebRootPath,"Upload/images");
            if (!Directory.Exists(appUploadPath))
            {
                Directory.CreateDirectory(appUploadPath);
            }
            var fileName = Guid.NewGuid().ToString() +"_"+ file.FileName;
            var fullPath = Path.Combine(appUploadPath, fileName);
            file.CopyTo(new FileStream(fullPath, FileMode.Create));
            return fileName;
        }
    }
}