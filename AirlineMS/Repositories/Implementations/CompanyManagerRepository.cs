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
{ public class CompanyManagerRepository : BaseRepository<CompanyManager>, ICompanyManagerRepository
        {
            public CompanyManagerRepository(Context context)
            {
                _context = context;
            }

            public CompanyManager Get(string Id)
            {
                return _context.CompanyManagers
                .Include(a => a.Company).Include(a => a.User)
                .FirstOrDefault(a => a.UserId == Id && a.IsDeleted == false);
            
            }

            public CompanyManager Get(Expression<Func<CompanyManager, bool>> expression)
            {
                return _context.CompanyManagers
                .Include(a => a.Company).Include(a => a.User)
                .FirstOrDefault(expression);
            }

     
        public IEnumerable<CompanyManager> GetAll()
            {
                return _context.CompanyManagers
                .Include(a => a.Company)
                .Where(a => a.IsDeleted == false)
                .ToList();
            }

            public IEnumerable<CompanyManager> GetSelected(List<string> ids)
            {
                return _context.CompanyManagers
                .Include(a => a.User)
                .Include(a => a.Company)
                .Where(a => a.IsDeleted == false)
                .ToList();
            }

            public IEnumerable<CompanyManager> GetSelected(Expression<Func<CompanyManager, bool>> expression)
            {
                return _context.CompanyManagers
                .Include(a => a.Company)
                .Where(expression)
                .ToList();
            }
        }
    }
    

