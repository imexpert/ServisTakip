using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using ServisTakip.Core.Entities;
using ServisTakip.Core.Entities.Concrete;
using ServisTakip.Core.Extensions;
using ServisTakip.Entities.Concrete;
using ServisTakip.Entities.DTOs.Reports;

namespace ServisTakip.DataAccess.Concrete.EntityFramework.Contexts
{
    /// <summary>
    /// Because this context is followed by migration for more than one provider
    /// works on PostGreSql db by default. If you want to pass sql
    /// When adding AddDbContext, use MsDbContext derived from it.
    /// </summary>
    public class ProjectDbContext : DbContext
    {
        /// <summary>
        /// in constructor we get IConfiguration, parallel to more than one db
        /// we can create migration.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="configuration"></param>
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Let's also implement the general version.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="configuration"></param>
        protected ProjectDbContext(DbContextOptions options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<DeviceBrand> DeviceBrands { get; set; }
        public DbSet<DeviceType> DeviceTypes { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<GroupClaim> GroupClaims { get; set; }
        public DbSet<DeviceService> DeviceServices { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<DeviceModel> DeviceModels { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ContractMaintenance> ContractMaintenances { get; set; }
        public DbSet<TechnicianDeviceServiceReportModel> TechnicianDeviceServiceReports { get; set; }
        public DbSet<OfferReportModel> OfferReports { get; set; }
        public DbSet<UserProcess> UserProcesses { get; set; }
        protected IConfiguration Configuration { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("ServisTakipContext"))
                    .EnableSensitiveDataLogging();

                base.OnConfiguring(optionsBuilder);
            }
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReference)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                entityReference.RecordDate = DateTime.Now;
                                entityReference.RecordUsername = Utils.Email;
                                entityReference.UpdateDate = DateTime.Now;
                                entityReference.UpdateUsername = Utils.Email;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                Entry(entityReference).Property(x => x.RecordDate).IsModified = false;
                                Entry(entityReference).Property(x => x.RecordUsername).IsModified = false;

                                entityReference.UpdateDate = DateTime.Now;
                                entityReference.UpdateUsername = Utils.Email;
                                break;
                            }
                    }

                    entityReference.Ip = Utils.ClientIp;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
