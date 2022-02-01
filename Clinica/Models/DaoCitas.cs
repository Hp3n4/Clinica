using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinica.Models
{
    public class DaoCitas
    {
        public void citasIns(citas cita)
        {
            using (var db = new ModelClinica())
            {
                db.citas.Add(cita);
                db.SaveChanges();
            }
        }

        public void citasDel(int idcita)
        {
            using (var db = new ModelClinica())
            {
                var cita = db.citas.Find(idcita);
                db.citas.Remove(cita);
                db.SaveChanges();
            }
        }

        public List<object[]> citasQry()
        {
            List<object[]> list = new List<object[]>();

            using (var db = new ModelClinica())
            {
                var query = from t in db.citas
                            select new
                            {
                                idcita = t.idcita,
                                paciente = t.pacientes.nombre,
                                medico = t.medicos.nombre,
                                diahora = t.diahora

                            };


                foreach (var t in query)
                {
                    object[] fila = new object[4];
                    fila[0] = t.idcita;
                    fila[1] = t.paciente;
                    fila[2] = t.medico;
                    fila[3] = t.diahora;

                    list.Add(fila);
                }

            }

            return list;
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