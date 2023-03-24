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
            return _context.Branches.FirstOrDefault(a => a.Id == id);
        }

        public Branch Get(Expression<Func<Branch, bool>> expression)
        {
           return _context.Branches.Include(a => a.Staffs).FirstOrDefault(expression);
        }

        public IEnumerable<Branch> GetAll()
        {
           return _context.Branches.ToList();
        }

        public IEnumerable<Branch> GetSelected(Expression<Func<Branch, bool>> expression)
        {
            return _context.Branches.Where(expression).ToList();
        }

        public IEnumerable<Branch> GetSelected(List<string> ids)
        {
           return _context.Branches.Where(a => ids.Contains(a.Id)).ToList();
        }
    }
}