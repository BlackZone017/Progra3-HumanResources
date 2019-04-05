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
    public class InformeVacacionesController : Controller
    {
        private Model1 db = new Model1();

        // GET: InformeVacaciones
        public ActionResult Index(string correspondiente)
        {
            var vacaciones = db.Vacaciones.Include(v => v.Empleado);
            if (!String.IsNullOrEmpty(correspondiente))
            {
                int i = 0;
                i = System.Convert.ToInt32(correspondiente);
                vacaciones = vacaciones.Where(tabla => tabla.correspondiente == i);
            }
            return View(vacaciones.ToList());
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
