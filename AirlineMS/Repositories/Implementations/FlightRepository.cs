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
    public class FlightRepository : BaseRepository<Flight>, IFlightRepository
    {
        public FlightRepository(Context context)
        {
            _context = context;
        }

        public Flight Get(string id)
        {
            return _context.Flights
            .Include(a => a.Aircraft)
            .FirstOrDefault(a => a.Id == id);
        }

        public Flight Get(Expression<Func<Flight, bool>> expression)
        {
            return _context.Flights
            .Include(a => a.Aircraft)
            .FirstOrDefault(expression);
        }

        public IEnumerable<Flight> GetAll()
        {
            return _context.Flights
            .Include(a => a.Aircraft)
            .Where(a => a.IsDeleted == false)
            .ToList();

        }

        public IEnumerable<Flight> GetSelected(List<string> ids)
        {
             return _context.Flights
            .Include(a => a.Aircraft)
            .Where(a => ids.Contains(a.Id) && a.IsDeleted == false)
            .ToList();
        }
        public IEnumerable<Flight> GetSelected(Expression<Func<Flight, bool>> expression)
        {
             return _context.Flights
            .Include(a => a.Aircraft)
            .Where(expression)
            .ToList();
        }

    }
}