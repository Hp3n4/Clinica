namespace Clinica
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class pacientes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public pacientes()
        {
            citas = new HashSet<citas>();
        }

        [Key]
        public int idpaciente { get; set; }

        [Required]
        [StringLength(200)]
        public string nombre { get; set; }

        [Column(TypeName = "date")]
        public DateTime nacimiento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<citas> citas { get; set; }
    }
}
