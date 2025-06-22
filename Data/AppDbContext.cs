using Conference_Management_System.Enums;
using Conference_Management_System.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Conference_Management_System.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :
        base(options)
        { }

        public DbSet<Person> People { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Invitation> Invitations { get; set; }
        public DbSet<Participation> Participations { get; set; }
        // public DbSet<EventType> EventTypes { get; set; } // Bu sətiri silin!
        public DbSet<Location> Locations { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ApplicationUser və Person arasında bir-bir əlaqə
            modelBuilder.Entity<AppUser>()
                .HasOne(a => a.Person)
                .WithOne(p => p.AppUser)
                .HasForeignKey<AppUser>(a => a.PersonId)
                .IsRequired(false); // PersonId null ola bilər (yeni qeydiyyatdan keçən istifadəçilər üçün)

            // One-to-one relationship between Invitation and Participation
            modelBuilder.Entity<Participation>()
                .HasKey(p => p.InvitationId);

            modelBuilder.Entity<Participation>()
                .HasOne(p => p.Invitation)
                .WithOne(i => i.Participation)
                .HasForeignKey<Participation>(p => p.InvitationId);

            // Enumların string kimi saxlanması (optional, amma tövsiyə olunur)
            modelBuilder.Entity<Event>()
                .Property(e => e.EventType)
                .HasConversion<string>();

            modelBuilder.Entity<Person>()
                .Property(p => p.Role)
                .HasConversion<string>();

            modelBuilder.Entity<Invitation>()
                .Property(i => i.Status)
                .HasConversion<string>();


            // Seed Data
            // EventType artıq ayrı bir entity deyil, birbaşa enum dəyərləri istifadə olunur
            modelBuilder.Entity<Location>().HasData(
                new Location { Id = 1, Name = "Baku Convention Center", Address = "Heydar Aliyev Ave", Capacity = 1000, CreatedAt = DateTime.Now, IsDeleted = false },
                new Location { Id = 2, Name = "Fairmont Baku", Address = "Mehdi Huseyn Street 1A", Capacity = 300, CreatedAt = DateTime.Now, IsDeleted = false }
            );

            modelBuilder.Entity<Organizer>().HasData(
                new Organizer { Id = 1, FullName = "Aliyev Anar", Email = "anar.aliyev@code.edu.az", CreatedAt = DateTime.Now, IsDeleted = false },
                new Organizer { Id = 2, FullName = "Huseynova Nigar", Email = "nigar.huseynova@code.edu.az", CreatedAt = DateTime.Now, IsDeleted = false }
            );

            modelBuilder.Entity<Person>().HasData(
                new Person { Id = 1, Name = "Elvin", Surname = "Quliyev", Email = "elvin.quliyev@example.com", Phone = "0501234567", Role = PersonRoleEnum.Tələbə, CreatedAt = DateTime.Now, IsDeleted = false },
                new Person { Id = 2, Name = "Ayşe", Surname = "Məmmədova", Email = "ayse.mammadova@example.com", Phone = "0709876543", Role = PersonRoleEnum.Müəllim, CreatedAt = DateTime.Now, IsDeleted = false },
                new Person { Id = 3, Name = "Fərid", Surname = "Həsənov", Email = "farid.hasanov@example.com", Phone = "0551112233", Role = PersonRoleEnum.Qonaq, CreatedAt = DateTime.Now, IsDeleted = false }
            );

            modelBuilder.Entity<Event>().HasData(
                new Event { Id = 1, Title = "ASP.NET Core Bootcamp", Description = "Kapsamlı ASP.NET Core Bootcamp", Date = DateTime.Now.AddDays(30), LocationId = 1, EventType = EventTypeEnum.Bootcamp, OrganizerId = 1, CreatedAt = DateTime.Now, IsDeleted = false },
                new Event { Id = 2, Title = "AI in Business Summit", Description = "Biznesdə süni intellektin tətbiqi", Date = DateTime.Now.AddDays(60), LocationId = 2, EventType = EventTypeEnum.Conference, OrganizerId = 2, CreatedAt = DateTime.Now, IsDeleted = false }
            );

            modelBuilder.Entity<Invitation>().HasData(
                new Invitation { Id = 1, EventId = 1, PersonId = 1, Status = InvitationStatusEnum.Pending, SentAt = DateTime.Now, CreatedAt = DateTime.Now, IsDeleted = false },
                new Invitation { Id = 2, EventId = 1, PersonId = 2, Status = InvitationStatusEnum.Accepted, SentAt = DateTime.Now, CreatedAt = DateTime.Now, IsDeleted = false },
                new Invitation { Id = 3, EventId = 2, PersonId = 3, Status = InvitationStatusEnum.Pending, SentAt = DateTime.Now, CreatedAt = DateTime.Now, IsDeleted = false }
            );
        }
    }
}
