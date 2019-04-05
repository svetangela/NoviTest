namespace NoviTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Korisnici")]
    public partial class Korisnici
    {
        [Key]
        [StringLength(20)]
        public string KorisnickoIme { get; set; }

        [Required]
        [StringLength(20)]
        public string Lozinka { get; set; }

        public int Uloga { get; set; }

        public virtual Uloge Uloge { get; set; }
    }
}
