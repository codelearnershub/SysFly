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
            return _context.Staffs
            .Include(a => a.User)
            .Include(a => a.Company)
            .FirstOrDefault(a => a.Id == id && a.IsDeleted == false);
        }

        public Staff Get(Expression<Func<Staff, bool>> expression)
        {
           return _context.Staffs
            .Include(a => a.User)
            .Include(a => a.Company)
            .Where(a => a.IsDeleted == false)
            .FirstOrDefault(expression);
        }

        

        public IEnumerable<Staff> GetAll()
        {
           return _context.Staffs
            .Include(a => a.User)
            .Include(a => a.Company)
            .Where(a => a.IsDeleted == false)
            .ToList();
        }

        public IEnumerable<Staff> GetSelected(Expression<Func<Staff, bool>> expression)
        {
            return _context.Staffs
            .Include(a => a.User)
            .Include(a => a.Company)
            .Where(expression)
            .ToList();
        }

        public IEnumerable<Staff> GetSelected(List<string> ids)
        {
           return _context.Staffs
            .Include(a => a.User)
            .Include(a => a.Company)
            .Where(a => ids.Contains(a.Id) && a.IsDeleted == false)
            .ToList();
        }

      
    }
    
}