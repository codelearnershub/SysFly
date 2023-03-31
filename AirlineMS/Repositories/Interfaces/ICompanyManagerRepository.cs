using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AirlineMS.Models.Entities;

namespace AirlineMS.Repositories.Interfaces
{
    public interface ICompanyManagerRepository :IBaseRepository<CompanyManager>
    {
        CompanyManager Get(string userId);
        CompanyManager Get(Expression<Func<CompanyManager,bool>> expression);
        IEnumerable<CompanyManager> GetSelected(List<string> ids);
        IEnumerable<CompanyManager> GetSelected(Expression<Func<CompanyManager,bool>> expression);
        IEnumerable<CompanyManager> GetAll();


        


        
    }
}