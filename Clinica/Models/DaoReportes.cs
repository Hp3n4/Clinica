using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Clinica.Models
{
    public class DaoReportes
    {
             
        

        public List<medicos> DepaProv()
        {
            List<medicos> list = new List<medicos>();

            using (var db = new ModelClinica())
            {
                var query = from med in db.medicos select med;

                foreach (var med in query)
                {
                    medicos medico = med;

                    foreach (var cit in med.citas)
                    {
                        var paciente = from pacient in db.pacientes
                                       where pacient.idpaciente.Equals(cit.idpaciente)
                                       select pacient;
                        foreach (var pacient in paciente)
                        {
                            pacientes pac = pacient;

                        }

                        medico.citas.Add(cit);

                    }
                    list.Add(medico);
                }
            }


            return list;
        }










    }






}









