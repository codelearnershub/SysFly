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
            var companyExist = _companyRepository.Get(c => c.Name == model.Name);
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
                Logo = Logo
            };

            _companyRepository.Create(newCompany);
            _companyRepository.Save();

            return new BaseResponse<CompanyDto>{
                Message = "Successful",
                Status = true,
                Data = new CompanyDto{
                    Id = newCompany.Id,
                    Name = newCompany.Name,
                    CACRegistrationNum = newCompany.CACRegistrationNum,
                    CACDocument = newCompany.CACDocument,
                    Logo = newCompany.Logo,
                }
            };
        }
        
        public BaseResponse<CompanyDto> Delete(string id)
        {
            var company = _companyRepository.Get(id);
            if (company is null)
            {
                return new BaseResponse<CompanyDto>{
                    Message = "Company not found",
                    Status = false
                };
            }

            company.IsDeleted = true;

            _companyRepository.Update(company);
            _companyRepository.Save();

            return new BaseResponse<CompanyDto>{
                Message = "Successful",
                Status = true,
                Data = new CompanyDto{
                    Id = company.Id,
                    Name = company.Name,
                    CACRegistrationNum = company.CACRegistrationNum,
                    CACDocument = company.CACDocument,
                    Logo = company.Logo,
                }
            };
        }

        public BaseResponse<CompanyDto> Get(string id)
        {
            var company = _companyRepository.Get(id);
            if (company == null)
            {
                return new BaseResponse<CompanyDto>{
                    Message = "Company not found",
                    Status = false
                };
            }

            return new BaseResponse<CompanyDto>
            {
                Message = "Successful",
                Status = true,
                Data = new CompanyDto
                {
                    Id = company.Id,
                    Name = company.Name,
                    CACRegistrationNum = company.CACRegistrationNum,
                    CACDocument = company.CACDocument,
                    Logo = company.Logo,
                }
            };
        }

        public BaseResponse<IEnumerable<CompanyDto>> GetAll()
        {
            var companies = _companyRepository.GetAll();
            if (companies == null)
            {
                return new BaseResponse<IEnumerable<CompanyDto>>{
                    Message = "No Company found",
                    Status = false
                };
            }

            return new BaseResponse<IEnumerable<CompanyDto>>{
                Message = "Successful",
                Status = true,
                Data = companies.Select(c => new CompanyDto{
                    Id = c.Id,
                    Name = c.Name,
                    CACRegistrationNum = c.CACRegistrationNum,
                    CACDocument = c.CACDocument,
                    Logo = c.Logo,
                })
            };
        }

        public BaseResponse<CompanyDto> Update(string id, UpdateCompanyRequestModel model)
        {
            var company = _companyRepository.Get(id);
            if (company is null)
            {
                return new BaseResponse<CompanyDto>{
                    Message = "Company not found",
                    Status = false
                };
            }

    

            _companyRepository.Create(company);
            _companyRepository.Save();

            return new BaseResponse<CompanyDto>{
                Message = "Successful",
                Status = true,
                Data = new CompanyDto{
                    Id = company.Id,
                    CACRegistrationNum = company.CACRegistrationNum,
                    CACDocument = company.CACDocument,
                    Logo = company.Logo,
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