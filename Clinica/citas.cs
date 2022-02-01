namespace Clinica
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class citas
    {
        [Key]
        public int idcita { get; set; }

        public int idpaciente { get; set; }

        public int idmedico { get; set; }

        public DateTime diahora { get; set; }

        public virtual medicos medicos { get; set; }

        public virtual pacientes pacientes { get; set; }
    }
}
