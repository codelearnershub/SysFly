using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AirlineMS.AppDbContext;
using AirlineMS.Models.Entities;
using AirlineMS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AirlineMS.Repositories.Implementations
{
    public class PassengerRepository : BaseRepository<Passenger>, IPassengerRepository
    {
        public PassengerRepository(Context context)
        {
            _context = context;
        }

        public Passenger Get(string id)
        {
            return _context.Passengers
            .FirstOrDefault(a => a.Id == id && a.IsDeleted == false);
        }

        public Passenger Get(Expression<Func<Passenger, bool>> expression)
        {
            return _context.Passengers
            .FirstOrDefault(expression);
        }

        public IEnumerable<Passenger> GetAll()
        {
            return _context.Passengers
             .ToList();
        }

        public IEnumerable<Passenger> GetSelected(Expression<Func<Passenger, bool>> expression)
        {
            return _context.Passengers
            .Where(expression)
            .ToList();
        }

        public IEnumerable<Passenger> GetSelected(List<string> ids)
        {
            return _context.Passengers
            .Where(a => ids.Contains(a.Id) && a.IsDeleted == false)
            .ToList();
        }
    }
}