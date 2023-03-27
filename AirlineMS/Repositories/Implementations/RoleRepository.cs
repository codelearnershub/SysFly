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
            return _context.Roles.FirstOrDefault(x => x.Id == id);
        }

        public Role Get(Expression<Func<Role, bool>> expression)
        {
            return _context.Roles.Include(a => a.UserRoles).FirstOrDefault(expression);
        }

        public IEnumerable<Role> GetAll()
        {
            return _context.Roles.ToList();
        }

        public IEnumerable<Role> GetSelected(Expression<Func<Role, bool>> expression)
        {
            return _context.Roles.Where(expression).ToList();
        }

        public IEnumerable<Role> GetSelected(List<string> ids)
        {
            return _context.Roles.Where(a => ids.Contains(a.Id)).ToList();
        }
    }
}