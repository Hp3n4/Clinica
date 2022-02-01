using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinica.Models
{
    public class DaoPacientes
    {
        public void pacientesIns(pacientes paciente)
        {
            using (var db = new ModelClinica())
            {
                db.pacientes.Add(paciente);
                db.SaveChanges();
            }
        }



        public void pacientesDel(int idpaciente)
        {
            using (var db = new ModelClinica())
            {
                var paciente = db.pacientes.Find(idpaciente);
                db.pacientes.Remove(paciente);
                db.SaveChanges();
            }
        }


        public List<pacientes> pacientesQry()
        {
            List<pacientes> list = new List<pacientes>();

            using (var db = new ModelClinica())
            {
                var query = from a in db.pacientes select a;

                foreach (var a in query)
                {
                    pacientes paciente = a;
                    list.Add(paciente);
                }
            }
            return list;
        }
    }
}