using Clinica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinica.Controllers
{
    public class MedicosController : Controller
    {
                private DaoMedicos daoMedicos;

        public MedicosController()
        {
            daoMedicos = new DaoMedicos();
        }

        [HttpPost]
        public JsonResult MedicosIns(int idespecialidad, string nombre)
        {
            string result = "";
            if (nombre != null
                && nombre.Trim().Length >= 10
                && nombre.Trim().Length <= 100)
            {
            medicos a = new medicos();
            a.idespecialidad = idespecialidad;
            a.nombre = nombre;
            daoMedicos.medicosIns(a);
            }
            else
            {
                result = "nombre de Medico [10, 100] caracteres";
            }
            return Json(new { msg = result, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult MedicosDel(int idmedico)
        {
            string result = "";
            daoMedicos.medicosDel(idmedico);
            return Json(new { msg = result, JsonRequestBehavior.AllowGet });
        }

        


        // GET: Medicos
        public ActionResult Index()
        {
            return View();
        }
    }
}