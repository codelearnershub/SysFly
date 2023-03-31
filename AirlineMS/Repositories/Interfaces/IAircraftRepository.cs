using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AirlineMS.Models.Entities;

namespace AirlineMS.Repositories.Interfaces
{
    public interface IAircraftRepository : IBaseRepository<Aircraft>
    {
        Aircraft Get(string id);
        Aircraft Get(Expression<Func<Aircraft, bool>> expression);
        IEnumerable<Aircraft> GetSelected(List<string> ids);
        IEnumerable<Aircraft> GetSelected(Expression<Func<Aircraft, bool>> expression);
        IEnumerable<Aircraft> GetAll();
    }
}