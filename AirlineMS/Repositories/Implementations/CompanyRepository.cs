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
            return _context.Companies.FirstOrDefault(c => c.Id == id);
        }

        public Company Get(Expression<Func<Company, bool>> expression)
        {
            return _context.Companies.Include(c => c.Staffs).FirstOrDefault(expression);
        }

        public IEnumerable<Company> GetAll()
        {
            return _context.Companies.ToList();
        }

        public IEnumerable<Company> GetSelected(List<string> ids)
        {
            return _context.Companies.Where(c => ids.Contains(c.Id)).ToList();
        }

        public IEnumerable<Company> GetSelected(Expression<Func<Company, bool>> expression)
        {
            return _context.Companies.Include(c => c.Staffs).Where(expression).ToList();
        }
    }
}