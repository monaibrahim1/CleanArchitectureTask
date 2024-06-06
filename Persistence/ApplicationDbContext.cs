using Domain;
using MediatR;

using Microsoft.EntityFrameworkCore;

using System.Reflection;

namespace Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Governorate> Governorate { get; set; }
        public DbSet<City> Citiy { get; set; }
        public DbSet<AddressCount> AddressCount { get; set; }
        public DbSet<User> User { get; set; }

        private readonly IPublisher _publisher;

        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IPublisher publisher)
        : base(options)
        {
            _publisher= publisher;
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var domainEvents = ChangeTracker.Entries<Entity>()
                .SelectMany(entry => entry.Entity.PopDomainEvents())
                .ToList();

            await PublishDomainEvents(domainEvents);

            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private async Task PublishDomainEvents(List<INotification> domainEvents)
        {
            foreach (var domainEvent in domainEvents)
            {
                await _publisher.Publish(domainEvent);
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;initial catalog=Clean;integrated security=True;MultipleActiveResultSets=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
            seedDate(modelBuilder);
        }

        private void seedDate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasData(new City() { Id = 1, GovernorateId = 6, Name = "Shubra" }, new City() { Id = 2, GovernorateId = 6, Name = "Obour" });

            modelBuilder.Entity<Governorate>().HasData(
                new Governorate() { Id = 1, Name = "Alexandria" },
                new Governorate() { Id = 2, Name = "Assiut" },
                new Governorate() { Id = 3, Name = "Aswan" },
                new Governorate() { Id = 4, Name = "Beheira" },
                new Governorate() { Id = 5, Name = "Bani Suef" },
                new Governorate() { Id = 6, Name = "Cairo" },
                new Governorate() { Id = 7, Name = "Daqahliya" },
                new Governorate() { Id = 8, Name = "Damietta" },
                new Governorate() { Id = 9, Name = "Fayyoum" },
                new Governorate() { Id = 10, Name = "Gharbiya" },
                new Governorate() { Id = 11, Name = "Giza" },
                new Governorate() { Id = 12, Name = "Helwan" },
                new Governorate() { Id = 13, Name = "Ismailia" },
                new Governorate() { Id = 14, Name = "Kafr El Sheikh" },
                new Governorate() { Id = 15, Name = "Luxor" },
                new Governorate() { Id = 16, Name = "Marsa Matrouh" },
                new Governorate() { Id = 17, Name = "Minya" },
                new Governorate() { Id = 18, Name = "Monofiya" },
                new Governorate() { Id = 19, Name = "New Valley" },
                new Governorate() { Id = 20, Name = "North Sinai" },
                new Governorate() { Id = 21, Name = "Port Said" },
                new Governorate() { Id = 22, Name = "Qalioubiya" },
                new Governorate() { Id = 23, Name = "Qena" },
                new Governorate() { Id = 24, Name = "Red Sea" },
                new Governorate() { Id = 25, Name = "Sharqiya" },
                new Governorate() { Id = 26, Name = "Sohag" },
                new Governorate() { Id = 27, Name = "South Sinai" },
                new Governorate() { Id = 28, Name = "Suez" },
                new Governorate() { Id = 29, Name = "Tanta" }
                );
        }
    }
}
