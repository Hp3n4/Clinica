namespace Clinica
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class medicos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public medicos()
        {
            citas = new HashSet<citas>();
        }

        [Key]
        public int idmedico { get; set; }

        public int idespecialidad { get; set; }

        [Required]
        [StringLength(200)]
        public string nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<citas> citas { get; set; }

        public virtual especialidades especialidades { get; set; }
    }
}
