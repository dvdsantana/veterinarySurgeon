using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using VeterinarySurgeon.Core.Entities;

namespace VeterinarySurgeon.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Animal> Animals { get; set; }

        public DbSet<Pet> Pets { get; set; }

        public DbSet<FamilyMember> FamilyMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // alternately this is built-in to EF Core 2.2
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Pet>()
                .HasOne(p => p.Animal)
                .WithMany(a => a.Pets)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .HasMany(o => o.Pets)
                .WithOne(p => p.Owner)
                .IsRequired();

            modelBuilder.Entity<FamilyMember>()
                .HasOne(o => o.Employee)
                .WithMany(f => f.FamilyMembers);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken()) =>
            await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        public override int SaveChanges() =>
            SaveChangesAsync().GetAwaiter().GetResult();
    }
}