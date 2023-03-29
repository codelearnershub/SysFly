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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(Context context)
        {
            _context = context;
        }
        public User Get(string id)
        {
           return _context.Users
           .Include(a => a.UserRoles)
           .ThenInclude(a => a.Role)
           .Where(a => a.IsDeleted == false)
           .FirstOrDefault(a => a.Id == id);
        }

        public User Get(Expression<Func<User, bool>> expression)
        {
            return _context.Users
           .Include(a => a.UserRoles)
           .ThenInclude(a => a.Role)
           .Where(a => a.IsDeleted == false)
           .FirstOrDefault(expression);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users
           .Include(a => a.UserRoles)
           .ThenInclude(a => a.Role)
           .Where(a => a.IsDeleted == false)
           .ToList();
        }

        public List<User> GetSelected(List<string> ids)
        {
            return _context.Users
           .Include(a => a.UserRoles)
           .ThenInclude(a => a.Role)
           .Where(a => ids.Contains(a.Id) && a.IsDeleted == false)
           .ToList();
        }

        public List<User> GetSelected(Expression<Func<User, bool>> expression)
        {
            return _context.Users
           .Include(a => a.UserRoles)
           .ThenInclude(a => a.Role)
           .Where(expression)
           .ToList();
        }
    }
}