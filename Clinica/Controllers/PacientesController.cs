using Clinica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinica.Controllers
{
    public class PacientesController : Controller
    {
        private DaoPacientes daoPacientes;

        public PacientesController()
        {
            daoPacientes = new DaoPacientes();
        }

        [HttpPost]
        public JsonResult PacientesIns(String nombre,DateTime nacimiento )
        {
            string result = "";

            //if (nombre != null
            //    && nombre.Trim().Length >= 10
            //    && nombre.Trim().Length <= 100)
            //{
                pacientes a = new pacientes();
                a.nombre = nombre;
                a.nacimiento = nacimiento;
                daoPacientes.pacientesIns(a);

            //}
            //else
            //{
            //    result = "nombre de autor [10, 100] caracteres";
            //}

            return Json(new { msg = result, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult PacientesDel(int idpaciente)
        {
            string result = "";

            daoPacientes.pacientesDel(idpaciente);

            return Json(new { msg = result, JsonRequestBehavior.AllowGet });
        }

       


        // GET: Pacientes
        public ActionResult Index()
        {
            return View();
        }
    }
}