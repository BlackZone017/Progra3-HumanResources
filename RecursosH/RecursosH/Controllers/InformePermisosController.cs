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
    public class InformePermisosController : Controller
    {
        private Model1 db = new Model1();

        /*public ActionResult LlenarCombo()
        {
            var permisos = db.Permisos.ToList();

            var listaEmpleados = new SelectList(permisos, "IdEmpleado");
            ViewBag.idEmpleado = listaEmpleados;

            return View();
        }*/

        // GET: InformePermisos
        public ActionResult Index(String codigoEmpleado)
        {
            var permisos = db.Permisos.Include(p => p.Empleado);
            //var emp = from tabla in db.EmpleadosActivos select tabla;

            ViewBag.codigoEmpleado = new SelectList(db.Empleadoes, "codigoEmpleado", "codigoEmpleado");
            if (!String.IsNullOrEmpty(codigoEmpleado))
            {
                //int i = 0;
                //i = System.Convert.ToInt32(idEmpleado);
                permisos = permisos.Where(tabla => tabla.Empleado.codigoEmpleado == codigoEmpleado);
            }
            return View(permisos.ToList());
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
