//namespace NoviTest.Models
//{
//    using System;
//    using System.Data.Entity;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Linq;

//    public partial class IzBaze : DbContext
//    {
//        public IzBaze()
//            : base("name=IzBaze")
//        {
//        }

//        public virtual DbSet<Korisnici> Korisnicis { get; set; }
//        public virtual DbSet<Predmet> Predmets { get; set; }
//        public virtual DbSet<Prijava> Prijavas { get; set; }
//        public virtual DbSet<Smer> Smers { get; set; }
//        public virtual DbSet<Student> Students { get; set; }
//        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
//        public virtual DbSet<Uloge> Uloges { get; set; }

//        protected override void OnModelCreating(DbModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Predmet>()
//                .HasMany(e => e.Prijavas)
//                .WithRequired(e => e.Predmet)
//                .WillCascadeOnDelete(false);

//            modelBuilder.Entity<Smer>()
//                .Property(e => e.Naziv)
//                .IsFixedLength();

//            modelBuilder.Entity<Smer>()
//                .HasMany(e => e.Students)
//                .WithRequired(e => e.Smer)
//                .WillCascadeOnDelete(false);

//            modelBuilder.Entity<Student>()
//                .HasMany(e => e.Prijavas)
//                .WithRequired(e => e.Student)
//                .WillCascadeOnDelete(false);

//            modelBuilder.Entity<Uloge>()
//                .HasMany(e => e.Korisnicis)
//                .WithRequired(e => e.Uloge)
//                .HasForeignKey(e => e.Uloga)
//                .WillCascadeOnDelete(false);
//        }
//    }
//}
