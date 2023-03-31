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
    public class BranchRepository : BaseRepository<Branch>, IBranchRepository
    {
        public BranchRepository(Context context)
        {
            _context = context;
        }
        public Branch Get(string id)
        {
            return _context.Branches
            .Include(a => a.Company)
            .FirstOrDefault(a => a.Id == id && a.IsDeleted == false);
        }

        public Branch Get(Expression<Func<Branch, bool>> expression)
        {
           return _context.Branches
            .Include(a => a.Company)
            .FirstOrDefault(expression);
        }

        public IEnumerable<Branch> GetAll()
        {
           return _context.Branches
            .Include(a => a.Company)
            .ToList();
        }

        public IEnumerable<Branch> GetSelected(Expression<Func<Branch, bool>> expression)
        {
            return _context.Branches
            .Include(a => a.Company)
            .Where(expression)
            .ToList();
        }

        public IEnumerable<Branch> GetSelected(List<string> ids)
        {
           return _context.Branches
            .Include(a => a.Company)
            .Where(a => ids.Contains(a.Id) && a.IsDeleted == false)
            .ToList();
        }
    }
}