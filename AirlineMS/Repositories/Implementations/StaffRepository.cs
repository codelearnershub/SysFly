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
    public class StaffRepository: BaseRepository<Staff>, IStaffRepository
    {
         public StaffRepository(Context context)
        {
            _context = context;
        }
        public Staff Get(string id)
        {
            return _context.Staffs.FirstOrDefault(a => a.Id == id);
        }

        public Staff Get(Expression<Func<Staff, bool>> expression)
        {
           return _context.Staffs.Include(a => a.user).FirstOrDefault(expression);
        }

        

        public IEnumerable<Staff> GetAll()
        {
           return _context.Staffs.ToList();
        }

        public IEnumerable<Staff> GetSelected(Expression<Func<Staff, bool>> expression)
        {
            return _context.Staffs.Where(expression).ToList();
        }

        public IEnumerable<Staff> GetSelected(List<string> ids)
        {
           return _context.Staffs.Where(a => ids.Contains(a.Id)).ToList();
        }

      
    }
    
}