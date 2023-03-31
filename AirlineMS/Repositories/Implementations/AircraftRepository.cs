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
    public class AircraftRepository : BaseRepository<Aircraft>, IAircraftRepository
    {
        public AircraftRepository(Context context)
        {
            _context = context;
        }
        public Aircraft Get(string id)
        {
            return _context.Aircrafts
            .Include(a => a.Company)
            .FirstOrDefault(a => a.Id == id && a.IsDeleted == false);
        }

        public Aircraft Get(Expression<Func<Aircraft, bool>> expression)
        {
            return _context.Aircrafts
           .Include(a => a.Company)
           .FirstOrDefault(expression);
        }

        public IEnumerable<Aircraft> GetAll()
        {
            return _context.Aircrafts
           .Include(a => a.Company)
           .ToList();
        }

        public IEnumerable<Aircraft> GetSelected(List<string> ids)
        {
             return _context.Aircrafts
            .Include(a => a.Company)
            .Where(a => ids.Contains(a.Id) && a.IsDeleted == false)
            .ToList();
        }

        public IEnumerable<Aircraft> GetSelected(Expression<Func<Aircraft, bool>> expression)
        {
            return _context.Aircrafts
            .Include(a => a.Company)
            .Where(expression)
            .ToList();
        }
    }
}