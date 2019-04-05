namespace NoviTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class proba : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Korisnici",
                c => new
                    {
                        KorisnickoIme = c.String(nullable: false, maxLength: 20),
                        Lozinka = c.String(nullable: false, maxLength: 20),
                        Uloga = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KorisnickoIme)
                .ForeignKey("dbo.Uloge", t => t.Uloga)
                .Index(t => t.Uloga);
            
            CreateTable(
                "dbo.Uloge",
                c => new
                    {
                        UlogaID = c.Int(nullable: false),
                        Opis = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.UlogaID);
            
            CreateTable(
                "dbo.Predmet",
                c => new
                    {
                        PredmetID = c.Int(nullable: false),
                        Naziv = c.String(nullable: false, maxLength: 40),
                        Profesor = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.PredmetID);
            
            CreateTable(
                "dbo.Prijava",
                c => new
                    {
                        PredmetID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                        Ocena = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PredmetID, t.StudentID })
                .ForeignKey("dbo.Student", t => t.StudentID)
                .ForeignKey("dbo.Predmet", t => t.PredmetID)
                .Index(t => t.PredmetID)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentID = c.Int(nullable: false),
                        Ime = c.String(nullable: false, maxLength: 15),
                        Prezime = c.String(nullable: false, maxLength: 20),
                        GodinaUpisa = c.Short(nullable: false),
                        DatumRodjenja = c.String(nullable: false, maxLength: 10),
                        Skolarina = c.Single(),
                        Prosek = c.Single(),
                        SmerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentID)
                .ForeignKey("dbo.Smer", t => t.SmerID)
                .Index(t => t.SmerID);
            
            CreateTable(
                "dbo.Smer",
                c => new
                    {
                        SmerID = c.Int(nullable: false),
                        Naziv = c.String(nullable: false, maxLength: 40, fixedLength: true),
                    })
                .PrimaryKey(t => t.SmerID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Prijava", "PredmetID", "dbo.Predmet");
            DropForeignKey("dbo.Student", "SmerID", "dbo.Smer");
            DropForeignKey("dbo.Prijava", "StudentID", "dbo.Student");
            DropForeignKey("dbo.Korisnici", "Uloga", "dbo.Uloge");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Student", new[] { "SmerID" });
            DropIndex("dbo.Prijava", new[] { "StudentID" });
            DropIndex("dbo.Prijava", new[] { "PredmetID" });
            DropIndex("dbo.Korisnici", new[] { "Uloga" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Smer");
            DropTable("dbo.Student");
            DropTable("dbo.Prijava");
            DropTable("dbo.Predmet");
            DropTable("dbo.Uloge");
            DropTable("dbo.Korisnici");
        }
    }
}
