using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.AvaiableServiceDirectory;
using WebApi.DayWorkDirectory;
using WebApi.ServiceDirectory;
using WebApi.UserDirectory;


namespace WebApi.DataContext
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {}
        public DbSet<Service> Services { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAdmin> Admins { get; set; }
        public DbSet<UserClient> Clients { get; set; }
        public DbSet<ItemService> Items { get; set; }
        public DbSet<DayWork> DayWorks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
            .HasDiscriminator<string>("Role")
            .HasValue<UserAdmin>("admin")
            .HasValue<UserClient>("client");

            builder.Entity<Service>()
                .HasOne(userAdmin => userAdmin.CreatedBy)
                .WithMany(userAdmin => userAdmin.CreatedServices);

            builder.Entity<Service>()
                .HasOne(userAdmin => userAdmin.ServiceProvider)
                .WithMany(userAdmin => userAdmin.OfferedServices);
        }
    }
}
