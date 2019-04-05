using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace NoviTest.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //Nasi entiteti

        public virtual DbSet<Korisnici> Korisnicis { get; set; }
        public virtual DbSet<Predmet> Predmets { get; set; }
        public virtual DbSet<Prijava> Prijavas { get; set; }
        public virtual DbSet<Smer> Smers { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Uloge> Uloges { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Predmet>()
                .HasMany(e => e.Prijavas)
                .WithRequired(e => e.Predmet)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Smer>()
                .Property(e => e.Naziv)
                .IsFixedLength();

            modelBuilder.Entity<Smer>()
                .HasMany(e => e.Students)
                .WithRequired(e => e.Smer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Prijavas)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Uloge>()
                .HasMany(e => e.Korisnicis)
                .WithRequired(e => e.Uloge)
                .HasForeignKey(e => e.Uloga)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}