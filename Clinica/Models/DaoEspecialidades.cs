
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinica.Models
{
    public class DaoEspecialidades
    {
        public void especialidadesIns(especialidades especialidad)
        {
            using (var db = new ModelClinica())
            {
                db.especialidades.Add(especialidad);
                db.SaveChanges();
            }
        }
    }


}