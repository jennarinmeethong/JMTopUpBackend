using JMTopUpBackend.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMTopUpBackend.Infrastructure.Contexts
{
    public class JMTopUpContext : DbContext
    {
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<UserProfile> UserProfiles { get; set; } = null!;
        public JMTopUpContext() : base() { }
        public JMTopUpContext(DbContextOptions<JMTopUpContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.UseCollation("THAI_CS_AS");
            modelBuilder.Entity<Role>(ba =>
            {
                ba.HasIndex(pe => pe.Name)
                    .IsUnique();
                ba.HasData(new Role
                {
                    Id = short.MaxValue,
                    Name = "Admin",
                    DescriptionTH = "แอดมิน",
                    DescriptionEN = "Admin",
                    CreatedBy = Guid.Empty,
                    CreatedOn = DateTime.Now,
                },
                new Role
                {
                    Id = 1,
                    Name = "Customer",
                    DescriptionTH = "ลูกค้า",
                    DescriptionEN = "Customer",
                    CreatedBy = Guid.Empty,
                    CreatedOn = DateTime.Now,
                });
            });
            modelBuilder.Entity<UserProfile>(ba =>
            {
                ba.HasIndex(pe => pe.UserName)
                    .IsUnique();
                ba.HasIndex(pe => pe.Email)
                    .IsUnique();
                ba.HasData(new UserProfile
                {
                    Id = Guid.Empty,
                    UserName = "JMAdmin",
                    Password = "JMAdmin",
                    Email = "JMAdmin@JMAdmin.com",
                    BirthDate = DateTime.MinValue,
                    RoleId = short.MaxValue,
                    IsVerified = true,
                    IsDisabled = false,
                    CreatedBy = Guid.Empty,
                    CreatedOn = DateTime.MinValue,
                });
            });
        }
    }
}
