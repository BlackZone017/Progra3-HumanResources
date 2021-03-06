﻿using System;
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
    public class EmpleadosInactivosController : Controller
    {
        private Model1 db = new Model1();

        // GET: EmpleadosInactivos
        public ActionResult Index()
        {
            return View(db.EmpleadosInactivos.ToList());
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
