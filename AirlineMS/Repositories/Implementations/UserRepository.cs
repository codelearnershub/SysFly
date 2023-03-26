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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(Context context)
        {
            _context = context;
        }
        public User Get(string id)
        {
           return _context.Users.FirstOrDefault(a => a.Id == id);
        }

        public User Get(Expression<Func<User, bool>> expression)
        {
            return _context.Users.FirstOrDefault(expression);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }
    }
}