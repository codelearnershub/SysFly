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
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(Context context)
        {
            _context = context;
        }

        public Company Get(string id)
        {
            return _context.Companies
            .Where(a => a.IsDeleted == false)
            .Include(a => a.Branches)
            .Include(a => a.Staffs)
            .ThenInclude(a => a.User)
            .FirstOrDefault(c => c.Id == id);
        }

        public Company Get(Expression<Func<Company, bool>> expression)
        {
            return _context.Companies
            .Where(a => a.IsDeleted == false)
            .Include(a => a.Branches)
            .Include(a => a.Staffs)
            .ThenInclude(a => a.User)
            .FirstOrDefault(expression);
        }

        public IEnumerable<Company> GetAll()
        {
            return _context.Companies
            .Where(a => a.IsDeleted == false)
            .Include(a => a.Branches)
            .Include(a => a.Staffs)
            .ThenInclude(a => a.User)
            .ToList();
        }

        public IEnumerable<Company> GetSelected(List<string> ids)
        {
            return _context.Companies
            .Where(a => ids.Contains(a.Id) && a.IsDeleted == false)
            .Include(a => a.Branches)
            .Include(a => a.Staffs)
            .ThenInclude(a => a.User)
            .ToList();
        }

        public IEnumerable<Company> GetSelected(Expression<Func<Company, bool>> expression)
        {
            return _context.Companies
            .Where(expression)
            .Include(a => a.Branches)
            .Include(a => a.Staffs)
            .ThenInclude(a => a.User)
            .ToList();
        }
    }
}