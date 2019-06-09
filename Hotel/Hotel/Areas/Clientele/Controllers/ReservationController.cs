using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Hotel.Areas.Clientele.Controllers
{
    public class ReservationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Clientele/Reservation
        public async Task<ActionResult> Index()
        {
            return View(await db.rooms.ToListAsync());
        }

        // GET: Clientele/Reservation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Clientele/Reservation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientele/Reservation/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Clientele/Reservation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Clientele/Reservation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Clientele/Reservation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Clientele/Reservation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
