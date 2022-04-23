using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebGYM.Models;

namespace WebGYM
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }

        public DbSet<Models.SchemeMaster> SchemeMaster { get; set; }
        public DbSet<PeriodTB> PeriodTb { get; set; }
        public DbSet<Models.PlanMaster> PlanMaster { get; set; }
        public DbSet<Models.Role> Role { get; set; }
        public DbSet<Models.MemberRegistration> MemberRegistration { get; set; }
        public DbSet<Models.Users> Users { get; set; }
        public DbSet<Models.UsersInRoles> UsersInRoles { get; set; }
        public DbSet<PaymentDetails> PaymentDetails { get; set; }
    }
}
