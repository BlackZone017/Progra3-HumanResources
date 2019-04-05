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
    public class EntradasController : Controller
    {
        private Model2 db = new Model2();

        // GET: Entradas
        public ActionResult Index()
        {
            //var entradas = from tabla in db.Entradas select tabla;
            return View(db.Entradas.ToList());
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
