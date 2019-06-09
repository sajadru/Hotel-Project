using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hotel;
using Hotel.Models;

namespace Hotel.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    public class PersonnelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Personnels
        public async Task<ActionResult> Index()
        {
            var personnels = db.personnels.Include(p => p.ApplicationUser);
            return View(await personnels.ToListAsync());
        }

        // GET: Admin/Personnels/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personnel personnel = await db.personnels.FindAsync(id);
            if (personnel == null)
            {
                return HttpNotFound();
            }
            return View(personnel);
        }

        // GET: Admin/Personnels/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Admin/Personnels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Family,NathionalCode,Phone,Age,Gender,PersonnelCode,Degree,WorkExperience")] Personnel personnel)
        {
            if (ModelState.IsValid)
            {
                db.personnels.Add(personnel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Users, "Id", "Email", personnel.Id);
            return View(personnel);
        }

        // GET: Admin/Personnels/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personnel personnel = await db.personnels.FindAsync(id);
            if (personnel == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Users, "Id", "Email", personnel.Id);
            return View(personnel);
        }

        // POST: Admin/Personnels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Family,NathionalCode,Phone,Age,Gender,PersonnelCode,Degree,WorkExperience")] Personnel personnel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personnel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Users, "Id", "Email", personnel.Id);
            return View(personnel);
        }

        // GET: Admin/Personnels/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personnel personnel = await db.personnels.FindAsync(id);
            if (personnel == null)
            {
                return HttpNotFound();
            }
            return View(personnel);
        }

        // POST: Admin/Personnels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Personnel personnel = await db.personnels.FindAsync(id);
            db.personnels.Remove(personnel);
            await db.SaveChangesAsync();
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
