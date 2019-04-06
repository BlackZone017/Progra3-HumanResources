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
    public class EmpleadoController : Controller
    {
        private Model1 db = new Model1();

        // GET: Empleado
        public ActionResult Index()
        {
            var empleados = db.Empleadoes.Include(e => e.Cargo).Include(e => e.Departamento);
            return View(empleados.ToList());
        }

        // GET: Empleado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleadoes.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleado/Create
        public ActionResult Create()
        {
            ViewBag.idCargo = new SelectList(db.Cargoes, "id", "codigoCargo");
            ViewBag.idDepartamento = new SelectList(db.Departamentoes, "id", "codigoDepartamento");
            return View();
        }

        // POST: Empleado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,codigoEmpleado,nombre,apellido,telefono,idDepartamento,idCargo,fechaIngreso,salario,estatus,idManager")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Empleadoes.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCargo = new SelectList(db.Cargoes, "id", "codigoCargo", empleado.idCargo);
            ViewBag.idDepartamento = new SelectList(db.Departamentoes, "id", "codigoDepartamento", empleado.idDepartamento);
            return View(empleado);
        }

        // GET: Empleado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleadoes.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCargo = new SelectList(db.Cargoes, "id", "codigoCargo", empleado.idCargo);
            ViewBag.idDepartamento = new SelectList(db.Departamentoes, "id", "codigoDepartamento", empleado.idDepartamento);
            return View(empleado);
        }

        // POST: Empleado/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,codigoEmpleado,nombre,apellido,telefono,idDepartamento,idCargo,fechaIngreso,salario,estatus,idManager")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCargo = new SelectList(db.Cargoes, "id", "codigoCargo", empleado.idCargo);
            ViewBag.idDepartamento = new SelectList(db.Departamentoes, "id", "codigoDepartamento", empleado.idDepartamento);
            return View(empleado);
        }

        // GET: Empleado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleadoes.Find(id);

            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            

            Empleado empleado = db.Empleadoes.Find(id);
            //db.Empleadoes.Remove(empleado);

            /*lo que le meti*/
            empleado.estatus = "Inactivo";
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Empleado/Activar/5
        public ActionResult Activar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleadoes.Find(id);

            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleado/Delete/5
        [HttpPost, ActionName("Activar")]
        [ValidateAntiForgeryToken]
        public ActionResult ActivarConfirmed(int id)
        {



            Empleado empleado = db.Empleadoes.Find(id);
            empleado.estatus = "Activo";
            db.SaveChanges();
            return RedirectToAction("Index");
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
