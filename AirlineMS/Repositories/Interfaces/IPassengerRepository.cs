using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AirlineMS.Models.Entities;

namespace AirlineMS.Repositories.Interfaces
{
    public interface IPassengerRepository : IBaseRespository<Passenger>
    {
        Passenger GetPassenger(string id);
        Passenger GetPassenger(Expression<Func<Passenger, bool>> expression);
        IEnumerable<Passenger> GetSelected(List<string> ids);
        IEnumerable<Passenger> GetSelected(Expression<Func<Passenger, bool>> expression);
        IEnumerable<Passenger> GetAll();
    }
}