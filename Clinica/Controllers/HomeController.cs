using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Properties;
using iText.Kernel.Colors;
using iText.Layout.Borders;
using iText.Layout.Element;


using Clinica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinica.Controllers
{
    public class HomeController : Controller
    {

        private DaoReportes daoReportes;

        public HomeController()
        {
            daoReportes = new DaoReportes();
        }


        public ActionResult DepaProv()
        {
            DepaProvCrea("c:/temp/DepaProv.pdf");
            return File("c:/temp/DepaProv.pdf", "application/pdf");
        }

        public virtual void DepaProvCrea(string ruta)
        {
            PdfWriter writer = new PdfWriter(ruta);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            //--------------------------------------------

            Table table = new Table(new float[] { 50f, 70f });
            table.SetWidth(UnitValue.CreatePercentValue(100));
            table.AddHeaderCell(new Cell()
                .SetBackgroundColor(new DeviceRgb(0, 120, 0))
                .Add(new Paragraph("Medico").SetFontColor(new DeviceRgb(255, 255, 255))));
            table.AddHeaderCell(new Cell()
                .SetBackgroundColor(new DeviceRgb(0, 120, 0))
                .Add(new Paragraph("Paciente").SetFontColor(new DeviceRgb(255, 255, 255))));

            List<medicos> list = daoReportes.DepaProv();

            foreach (medicos med in list)
            {
                string d = med.nombre;
                //string p = med.nombre;
                foreach (citas cit in med.citas)
                {
                    var p = (cit.idpaciente).ToString();
                    string c = cit.pacientes.nombre;
                    using (var db = new ModelClinica())
                    {
                        var query = from pa in db.pacientes
                                    where Convert.ToString(pa.idpaciente) == p
                                    select new {pa.nombre };
                       
                    }
                    table.AddCell(new Cell()
                        .SetBorderBottom(new SolidBorder(ColorConstants.LIGHT_GRAY, 0.5f))
                        .SetBorderRight(new SolidBorder(ColorConstants.LIGHT_GRAY, 0.5f))
                        .Add(new Paragraph(new Text(d).SetFontSize(8))));
                    table.AddCell(new Cell()
                       .SetBorderBottom(new SolidBorder(ColorConstants.LIGHT_GRAY, 0.5f))
                       .SetBorderRight(new SolidBorder(ColorConstants.LIGHT_GRAY, 0.5f))
                       .Add(new Paragraph(new Text(c).SetFontSize(8))));
                    d = "";


                }
            }
            document.Add(table);

            //---------------------------------------------
            document.Close();
        }


        [HttpGet]
        public JsonResult ListaPacientes()
        {
            List<object[]> list = new List<object[]>();

            using (var db = new ModelClinica())
            {
                var query = from pac in db.pacientes
                            select new
                            {
                                idpaciente = pac.idpaciente,
                                nombre = pac.nombre
                            };

                foreach (var d in query)
                {
                    list.Add(new object[] { d.idpaciente, d.nombre });
                }
            }

            return Json(list, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Pacientes()
        {
            DaoPacientes daoPacientes = new DaoPacientes(); ;

            List<pacientes> list = daoPacientes.pacientesQry();

            ViewBag.Lista = list;
            return View();
        }

        public ActionResult Citas()
        {
            DaoCitas daoCitas = new DaoCitas();

            List<especialidades> list = daoCitas.especialidadesQry();
            ViewBag.Lista = list;

            string accion = Request["accion"];

            List<object[]> listar = daoCitas.citasQry();

            ViewBag.Listar = listar;




            ViewBag.Lista = list;
            return View();
        }



        public ActionResult Medicos()
        {
            DaoMedicos daoMedicos = new DaoMedicos(); 

            List<especialidades> list = daoMedicos.especialidadesQry();

            ViewBag.Lista = list;
            return View();
        }
    }
}