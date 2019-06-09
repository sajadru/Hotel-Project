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
    public class ReferredsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Referreds
        public async Task<ActionResult> Index()
        {
            var referreds = db.referreds.Include(r => r.ApplicationUser);
            return View(await referreds.ToListAsync());
        }

        // GET: Admin/Referreds/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Referred referred = await db.referreds.FindAsync(id);
            if (referred == null)
            {
                return HttpNotFound();
            }
            return View(referred);
        }

        // GET: Admin/Referreds/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Admin/Referreds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Family,NathionalCode,Phone,Age,Gender,RoomNumber,StayingTime")] Referred referred)
        {
            if (ModelState.IsValid)
            {
                db.referreds.Add(referred);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Users, "Id", "Email", referred.Id);
            return View(referred);
        }

        // GET: Admin/Referreds/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Referred referred = await db.referreds.FindAsync(id);
            if (referred == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Users, "Id", "Email", referred.Id);
            return View(referred);
        }

        // POST: Admin/Referreds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Family,NathionalCode,Phone,Age,Gender,RoomNumber,StayingTime")] Referred referred)
        {
            if (ModelState.IsValid)
            {
                db.Entry(referred).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Users, "Id", "Email", referred.Id);
            return View(referred);
        }

        // GET: Admin/Referreds/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Referred referred = await db.referreds.FindAsync(id);
            if (referred == null)
            {
                return HttpNotFound();
            }
            return View(referred);
        }

        // POST: Admin/Referreds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Referred referred = await db.referreds.FindAsync(id);
            db.referreds.Remove(referred);
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
