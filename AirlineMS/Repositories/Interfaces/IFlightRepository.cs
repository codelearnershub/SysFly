using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AirlineMS.Models.Entities;

namespace AirlineMS.Repositories.Interfaces
{
    public interface IFlightRepository : IBaseRepository<Flight>
    {
        Flight Get(string id);
        Flight Get(Expression<Func<Flight, bool>> expression);
        IEnumerable<Flight> GetSelected(List<string> ids);
        IEnumerable<Flight> GetSelected(Expression<Func<Flight, bool>> expression);
        IEnumerable<Flight> GetAll();
    }
    
}