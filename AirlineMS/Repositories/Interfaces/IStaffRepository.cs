using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AirlineMS.Models.Entities;

namespace AirlineMS.Repositories.Interfaces
{
    public interface IStaffRepository : IBaseRepository<Staff>
    {
        Staff Get(string id);
        Staff Get(Expression<Func<Staff,bool>> expression);
        IEnumerable<Staff> GetAll();
        IEnumerable<Staff> GetSelected(Expression<Func<Staff,bool>> expression);
         IEnumerable<Staff> GetSelected(List<string> ids);
    }
}