using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirlineMS.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AirlineMS.AppDbContext
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Branch> Branches {get; set;}
        public DbSet<BranchManager> BranchManagers {get; set;}
        public DbSet<Company> Companies {get; set;}
        public DbSet<Staff> Staffs {get; set;}
        public DbSet<User> Users {get;set;}
        public DbSet<Role> Roles {get; set;}
        public DbSet<UserRole> UserRoles {get;set;}
<<<<<<< HEAD

        public DbSet<CompanyManager> CompanyManagers {get; set;}

=======
<<<<<<< HEAD
        public DbSet<Aircraft> Aircrafts {get; set;}
=======
<<<<<<< HEAD
        public DbSet<Airport> Airporte {get;set;}
=======
        public DbSet<Flight> Flights {get; set;}
>>>>>>> master
>>>>>>> master
>>>>>>> master
    }
}