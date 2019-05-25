using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PlayerSelector.Models;

namespace PlayerSelector.Controllers
{
    public class PlayerInTeamsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PlayerInTeams
        public ActionResult Index()
        {
            return View(db.PlayerInTeams.ToList());
        }

        // GET: PlayerInTeams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerInTeam playerInTeam = db.PlayerInTeams.Find(id);
            if (playerInTeam == null)
            {
                return HttpNotFound();
            }
            return View(playerInTeam);
        }

        // GET: PlayerInTeams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlayerInTeams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NumberOfGoals")] PlayerInTeam playerInTeam)
        {
            if (ModelState.IsValid)
            {
                db.PlayerInTeams.Add(playerInTeam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(playerInTeam);
        }

        // GET: PlayerInTeams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerInTeam playerInTeam = db.PlayerInTeams.Find(id);
            if (playerInTeam == null)
            {
                return HttpNotFound();
            }
            return View(playerInTeam);
        }

        // POST: PlayerInTeams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NumberOfGoals")] PlayerInTeam playerInTeam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(playerInTeam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(playerInTeam);
        }

        // GET: PlayerInTeams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerInTeam playerInTeam = db.PlayerInTeams.Find(id);
            if (playerInTeam == null)
            {
                return HttpNotFound();
            }
            return View(playerInTeam);
        }

        // POST: PlayerInTeams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlayerInTeam playerInTeam = db.PlayerInTeams.Find(id);
            db.PlayerInTeams.Remove(playerInTeam);
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
