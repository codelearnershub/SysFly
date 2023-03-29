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
       private readonly ICompanyRepository _companyRepository;
       private readonly IWebHostEnvironment _webHostEnvironment;

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
            var objExists = _companyRepository.Get(d => d.Id == id);
             if (objExists != null)
            {
               objExists.IsDeleted = true;
               _companyRepository.Update(objExists);
               _companyRepository.Save();
               
                return new BaseResponse<CompanyDto>{
                    Message = "successful",
                    Status = true
                };
            }
             return new BaseResponse<CompanyDto>{
                    Message = "Company already exists",
                    Status = false
                };

        }

        public BaseResponse<CompanyDto> Get(string id)
        {
            var companyExists = _companyRepository.Get(g => g.Id == id);
            if(companyExists != null)
            {
                companyExists.IsDeleted = false;
                _companyRepository.Update(companyExists);
                _companyRepository.Save();

                return new BaseResponse<CompanyDto>{
                    Message = "successful",
                    Status = false
                };
            }
             return new BaseResponse<CompanyDto>{
                    Message = "Company is not fund",
                    Status = true
                };
        }

        public BaseResponse<IEnumerable<CompanyDto>> GetAll()
        {
             var companies = _companyRepository.GetAll();
            if (companies == null)
            {
                return new BaseResponse<IEnumerable<CompanyDto>>{
                    Message = "No Company found",
                    Status = true
                };
            }

            return new BaseResponse<IEnumerable<CompanyDto>>{
                Message = "Successful",
                Status = false,
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
            throw new NotImplementedException();
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