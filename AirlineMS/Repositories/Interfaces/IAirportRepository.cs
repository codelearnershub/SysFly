using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AirlineMS.Models.Entities;

namespace AirlineMS.Repositories.Interfaces
{
    public interface IAirportRepository : IBaseRepository<Airport>
    {
         Airport Get(string id);
         Airport Get(Expression<Func<Airport, bool>> expression);
         IEnumerable<Airport> GetSelected(List<string> ids);
         IEnumerable<Airport> GetSelected(Expression<Func<Airport , bool>> expression);
         IEnumerable<Airport> GetAll();
         
    }
}