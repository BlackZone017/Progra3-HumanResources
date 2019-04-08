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
        public ActionResult Index(string nombre, string idDepartamento)
        {
            var emp = from tabla in db.EmpleadosActivos select tabla;

            if (!String.IsNullOrEmpty(nombre))
            {
                
                emp = emp.Where(tabla => tabla.nombre.Contains(nombre));
            }

            if (!String.IsNullOrEmpty(idDepartamento))
            {
                int i = 0;
                i = System.Convert.ToInt32(idDepartamento);
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
