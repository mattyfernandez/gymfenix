using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GimnasioFenix.Models;

namespace GimnasioFenix.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ActividadesController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Actividades
        public ActionResult Index()
        {
            var actividad = db.Actividad.Include(a => a.Dia).Include(a => a.Horario).Include(a => a.Profesor);
            return View(actividad.ToList());
        }

        // GET: Actividades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actividad actividad = db.Actividad.Find(id);
            if (actividad == null)
            {
                return HttpNotFound();
            }
            return View(actividad);
        }

        // GET: Actividades/Create
        public ActionResult Create()
        {
            ViewBag.IdDia = new SelectList(db.Dia, "Id", "Dia1");
            ViewBag.IdHorario = new SelectList(db.Horario, "Id", "Horario1");
            ViewBag.IdProfesor = new SelectList(db.Profesor, "Id", "Nombre");
            return View();
        }

        // POST: Actividades/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Actividad1,Estado,Cupos,IdDia,IdHorario,IdProfesor")] Actividad actividad)
        {
            if (ModelState.IsValid)
            {
                db.Actividad.Add(actividad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdDia = new SelectList(db.Dia, "Id", "Dia1", actividad.IdDia);
            ViewBag.IdHorario = new SelectList(db.Horario, "Id", "Horario1", actividad.IdHorario);
            ViewBag.IdProfesor = new SelectList(db.Profesor, "Id", "Nombre", actividad.IdProfesor);
            return View(actividad);
        }

        // GET: Actividades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actividad actividad = db.Actividad.Find(id);
            if (actividad == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDia = new SelectList(db.Dia, "Id", "Dia1", actividad.IdDia);
            ViewBag.IdHorario = new SelectList(db.Horario, "Id", "Horario1", actividad.IdHorario);
            ViewBag.IdProfesor = new SelectList(db.Profesor, "Id", "Nombre", actividad.IdProfesor);
            return View(actividad);
        }

        // POST: Actividades/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Actividad1,Estado,Cupos,IdDia,IdHorario,IdProfesor")] Actividad actividad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actividad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdDia = new SelectList(db.Dia, "Id", "Dia1", actividad.IdDia);
            ViewBag.IdHorario = new SelectList(db.Horario, "Id", "Horario1", actividad.IdHorario);
            ViewBag.IdProfesor = new SelectList(db.Profesor, "Id", "Nombre", actividad.IdProfesor);
            return View(actividad);
        }

        // GET: Actividades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actividad actividad = db.Actividad.Find(id);
            if (actividad == null)
            {
                return HttpNotFound();
            }
            return View(actividad);
        }

        // POST: Actividades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Actividad actividad = db.Actividad.Find(id);
            db.Actividad.Remove(actividad);
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
