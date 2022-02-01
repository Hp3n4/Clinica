using Clinica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinica.Controllers
{
    public class CitasController : Controller
    {

        private DaoCitas daoCitas;

        public CitasController()
        {
            daoCitas = new DaoCitas();
        }


        [HttpPost]
        public JsonResult CitasIns(int idpaciente,int idmedico, DateTime diahora)
        {
           string result = "";

            //if (idpaciente.ToString() != null
            //    && idpaciente.ToString().Trim().Length >= 10
            //    && idpaciente.ToString().Trim().Length <= 100)
            //{
                citas a = new citas();
                a.idpaciente = idpaciente;
                a.idmedico = idmedico;
                a.diahora = diahora;
                daoCitas.citasIns(a);
            //}
            //else
            //{
            //    result = "nombre de Medico [10, 100] caracteres";
            //}
            return Json(new { msg = result, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult CitasDel(int idcita)
        {
            string result = "";
            daoCitas.citasDel(idcita);
            return Json(new { msg = result, JsonRequestBehavior.AllowGet });
        }

        // GET: Citas
        public ActionResult Index()
        {
            return View();
        }
    }
}