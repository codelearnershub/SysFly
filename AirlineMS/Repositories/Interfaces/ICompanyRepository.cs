using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AirlineMS.Models.Entities;

namespace AirlineMS.Repositories.Interfaces
{
    public interface ICompanyRepository : IBaseRepository<Company>
    {
        Company Get(string id);
        Company Get(Expression<Func<Company, bool>> expression);
        IEnumerable<Company> GetSelected(List<string> ids);
        
        IEnumerable<Company> GetSelected(Expression<Func<Company, bool>> expression);
        IEnumerable<Company> GetAll();
    }
}