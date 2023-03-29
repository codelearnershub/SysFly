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
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(Context context)
        {
            _context = context;
        }
        public Role Get(string id)
        {
            return _context.Roles
            .Where(a => a.IsDeleted == false)
            .Include(a => a.UserRoles)
            .ThenInclude(a => a.User)
            .FirstOrDefault(x => x.Id == id);
        }

        public Role Get(Expression<Func<Role, bool>> expression)
        {
            return _context.Roles
            .Where(a => a.IsDeleted == false)
            .Include(a => a.UserRoles)
            .ThenInclude(a => a.User)
            .FirstOrDefault(expression);
        }

        public IEnumerable<Role> GetAll()
        {
            return _context.Roles
            .Where(a => a.IsDeleted == false)
            .Include(a => a.UserRoles)
            .ThenInclude(a => a.User)
            .ToList();
        }

        public IEnumerable<Role> GetSelected(Expression<Func<Role, bool>> expression)
        {
            return _context.Roles
            .Include(a => a.UserRoles)
            .ThenInclude(a => a.User)
            .Where(expression)
            .ToList();
        }

        public IEnumerable<Role> GetSelected(List<string> ids)
        {
            return _context.Roles
            .Include(a => a.UserRoles)
            .ThenInclude(a => a.User)
            .Where(a => ids.Contains(a.Id) && a.IsDeleted == false)
            .ToList();
        }
    }
}