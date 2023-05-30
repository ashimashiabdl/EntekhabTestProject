using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.OvetimePolicies.data
{
    public class EmployeeContext : Microsoft.EntityFrameworkCore.DbContext
    {
        private readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;
        public EmployeeContext()
        {

        }
        public EmployeeContext(DbContextOptions<EmployeeContext> options, Microsoft.Extensions.Configuration.IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        public Microsoft.EntityFrameworkCore.DbSet<Employee> Employees { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<EmployeeMonthlySalary> EmployeeMonthlySalarys { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                  .SelectMany(t => t.GetForeignKeys())
                  .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

       

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
#if DEBUG
            optionsBuilder.UseSqlServer(@"Data Source=.;TrustServerCertificate=True;Initial Catalog=TestProject;trusted_connection=true;");
#endif
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

     
    }
}
