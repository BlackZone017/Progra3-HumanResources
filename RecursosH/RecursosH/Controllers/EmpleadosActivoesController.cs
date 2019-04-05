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
        public ActionResult Index(string nombre)
        {
            var emp = from tabla in db.EmpleadosActivos select tabla;

            if (!String.IsNullOrEmpty(nombre))
            {
                emp = emp.Where(tabla => tabla.nombre == nombre);
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
