using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AirlineMS.Models.Entities;

namespace AirlineMS.Repositories.Interfaces
{
    public interface IUserRepository :IBaseRepository<User>
    {
        User Get(string id);
        User Get(Expression<Func<User,bool>> expression);
        IEnumerable<User> GetAll();
    }
}