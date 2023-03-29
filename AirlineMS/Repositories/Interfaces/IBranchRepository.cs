using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AirlineMS.Models.Entities;

namespace AirlineMS.Repositories.Interfaces
{
    public interface IBranchRepository : IBaseRepository<Branch>
    {
        Branch Get(string id);
        Branch Get(Expression<Func<Branch,bool>> expression);
        IEnumerable<Branch> GetSelected(List<string> ids);
        IEnumerable<Branch> GetSelected(Expression<Func<Branch,bool>> expression);
        IEnumerable<Branch> GetAll();
    }
}