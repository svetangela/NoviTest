namespace NoviTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Predmet")]
    public partial class Predmet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Predmet()
        {
            Prijavas = new HashSet<Prijava>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PredmetID { get; set; }

        [Required]
        [StringLength(40)]
        public string Naziv { get; set; }

        [StringLength(30)]
        public string Profesor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prijava> Prijavas { get; set; }
    }
}
