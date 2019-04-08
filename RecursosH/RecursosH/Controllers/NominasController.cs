using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RecursosH.Models;

namespace RecursosH.Controllers
{
    public class NominasController : Controller
    {
        private Model1 db = new Model1();

        // GET: Nominas
        public ActionResult Index(string mes, string año, string Button)
        {
            var emp = from tabla in db.Nominas.ToList() select tabla;

            if (!String.IsNullOrEmpty(mes))
            {

                emp = emp.Where(tabla => tabla.mes == mes);
            }

            if (!String.IsNullOrEmpty(año))
            {
                int i = 0;
                i = System.Convert.ToInt32(año);
                emp = emp.Where(tabla => tabla.año == i);
            }

            if (Button == "Generar Nomina")
            {
                db.Database.ExecuteSqlCommand("exec Calcular_Nomina");
                ViewBag.mensaje = "Nomina Actualizada";
            }

            return View(emp.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
