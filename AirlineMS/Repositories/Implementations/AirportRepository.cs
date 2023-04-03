using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AirlineMS.AppDbContext;
using AirlineMS.Models.Entities;
using AirlineMS.Repositories.Interfaces;

namespace AirlineMS.Repositories.Implementations
{
    public class AirportRepository : BaseRepository<Airport>, IAirportRepository
    {
        public AirportRepository(Context context)
        {
            _context = context;
        }


        public Airport Get(Expression<Func<Airport, bool>> expression)
        {
             return _context.Airports.FirstOrDefault(expression);

        }

        public Airport Get(string id)
        {
            return _context.Airports
            .FirstOrDefault(c => c.Id == id && c.IsDeleted == false);
        }

        public IEnumerable<Airport> GetAll()
        {
            return _context.Airports.Where(m => m.IsDeleted == false).ToList();
        }

        public IEnumerable<Airport> GetSelected(List<string> ids)
        {
            return _context.Airports.Where(p => ids.Contains(p.Id) && p.IsDeleted == false).ToList();
        }

        public IEnumerable<Airport> GetSelected(Expression<Func<Airport, bool>> expression)
        {
            throw new NotImplementedException();
        }

       
    }
}