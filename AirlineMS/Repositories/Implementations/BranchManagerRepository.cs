using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AirlineMS.AppDbContext;
using AirlineMS.Models.Dtos;
using AirlineMS.Models.Entities;
using AirlineMS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AirlineMS.Repositories.Implementations
{
    public class BranchManagerRepository : BaseRepository<BranchManager>, IBranchManagerRepository
    {
        public BranchManagerRepository(Context context)
        {
            _context = context;
        }

        public BranchManager Get(string id)
        {
            return _context.BranchManagers
            .Include(m => m.User)
            .Include(m => m.Branch)
            .FirstOrDefault(m => m.Id == id && m.IsDeleted == false);
        }

        public BranchManager Get(Expression<Func<BranchManager, bool>> expression)
        {
            return _context.BranchManagers
            .Include(m => m.User)
            .Include(m => m.Branch)
            .FirstOrDefault(expression);
        }
    }
}