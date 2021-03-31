using Microsoft.EntityFrameworkCore;
using UserDetails.Domain.Models;
namespace UserDetails.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserAddressDetail> UserAddressDetails { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           
            builder.Entity<UserAddressDetail>().ToTable("UserAddressDetails");
            builder.Entity<UserAddressDetail>().HasKey(p => p.Id);
            builder.Entity<UserAddressDetail>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<UserAddressDetail>().Property(p => p.startDate).IsRequired().HasMaxLength(50);
            builder.Entity<UserAddressDetail>().Property(p => p.endDate).IsRequired();
            builder.Entity<UserAddressDetail>().Property(p => p.houseNumber).IsRequired();
            builder.Entity<UserAddressDetail>().Property(p => p.postCode);
            builder.Entity<UserAddressDetail>().HasData
          (
              new UserAddressDetail { Id = 1, houseNumber = 57, postCode = "CB2 9JF" } // Id set manually due to in-memory provider

          );
            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.id);
            builder.Entity<User>().Property(p => p.id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.firstName).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.surName);
            builder.Entity<User>().Property(p => p.dateOfBirth);
            builder.Entity<User>().HasOne(s => s.userAddressDetail).WithMany(s => s.Users).HasForeignKey(s => s.UserAddressId);
            // builder.Entity<User>().HasOne(p => p.userAddressDetail).WithOne(p => p.User);




            builder.Entity<User>().HasData
            (
                new User { id = 1, firstName = "Sowmya", surName = "Gargatti" ,UserAddressId=1}, // Id set manually due to in-memory provider
                new User { id = 2, firstName = "Test", surName = "Agent", UserAddressId = 1 }
            );
            

           
           
        }
    }
}