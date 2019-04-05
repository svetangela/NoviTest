namespace NoviTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            Prijavas = new HashSet<Prijava>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentID { get; set; }

        [Required]
        [StringLength(15)]
        public string Ime { get; set; }

        [Required]
        [StringLength(20)]
        public string Prezime { get; set; }

        public short GodinaUpisa { get; set; }

        [Required]
        [StringLength(10)]
        public string DatumRodjenja { get; set; }

        public float? Skolarina { get; set; }

        public float? Prosek { get; set; }

        public int SmerID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prijava> Prijavas { get; set; }

        public virtual Smer Smer { get; set; }
    }
}
