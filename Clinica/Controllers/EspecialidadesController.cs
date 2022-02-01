using Clinica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinica.Controllers
{
    public class EspecialidadesController : Controller
    {
        private DaoEspecialidades daoEspecialidades;

        public EspecialidadesController()
        {
            daoEspecialidades = new DaoEspecialidades();
        }           

    [HttpPost]
    public JsonResult EspecialidadesIns(int idespecialidad, string especialidad)
    {
        string result = "";

        if (especialidad != null
            && especialidad.Trim().Length >= 10
            && especialidad.Trim().Length <= 100)
        {
            especialidades a = new especialidades();
            a.idespecialidad = idespecialidad;
            a.especialidad = especialidad;
            daoEspecialidades.especialidadesIns(a);
        }
        else
        {
            result = "nombre de Medico [10, 100] caracteres";
        }
        return Json(new { msg = result, JsonRequestBehavior.AllowGet });
    }



    // GET: Especialidades
    public ActionResult Index()
        {
            return View();
        }
    }
}