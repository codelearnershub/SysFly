using System.Linq.Expressions;
using AirlineMS.Models.Entities;
using AirlineMS.Repositories.Interfaces;

public interface IBranchManagerRepository : IBaseRepository<BranchManager>
{
        BranchManager Get(string id);
        BranchManager Get(Expression<Func<BranchManager,bool>> expression);
}