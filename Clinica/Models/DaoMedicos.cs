using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinica.Models
{
    public class DaoMedicos
    {
        public void medicosIns(medicos medico)
        {
            using (var db = new ModelClinica())
            {
                db.medicos.Add(medico);
                db.SaveChanges();
            }
        }

        public void medicosDel(int idmedico)
        {
            using (var db = new ModelClinica())
            {
                var medico = db.medicos.Find(idmedico);
                db.medicos.Remove(medico);
                db.SaveChanges();
            }
        }

       




        public List<especialidades> especialidadesQry()
        {
            List<especialidades> list = new List<especialidades>();

            using (var db = new ModelClinica())
            {
                var query = from a in db.especialidades select a;

                foreach (var a in query)
                {
                    especialidades especialidad = a;

                    foreach (var f in a.medicos)
                    {
                        a.medicos.Add(f);
                    }

                    list.Add(especialidad);
                }
            }

            return list;
        }
    }
}