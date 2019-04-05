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
    public class EmpleadosActivoesController : Controller
    {
        private Model1 db = new Model1();

        // GET: EmpleadosActivoes
        [HttpGet]
        public ActionResult Index(string nombre, string idDepart)
        {
            var emp = from tabla in db.EmpleadosActivos select tabla;

            if (!String.IsNullOrEmpty(nombre) && String.IsNullOrEmpty(idDepart))
            {
                idDepart = "0";
                emp = emp.Where(tabla => tabla.nombre == nombre);
            }
            else if (!String.IsNullOrEmpty(idDepart) && String.IsNullOrEmpty(nombre))
            {
                int i = 0;
                i = System.Convert.ToInt32(idDepart);
                emp = emp.Where(tabla => tabla.idDepartamento == i);
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
