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
    public class PlayerInTeamController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /PlayerInTeam/
        public ActionResult Index()
        {
            return View(db.PlayerInTeams.ToList());
        }

        // GET: /PlayerInTeam/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerInTeam playerinteam = db.PlayerInTeams.Find(id);
            if (playerinteam == null)
            {
                return HttpNotFound();
            }
            return View(playerinteam);
        }

        // GET: /PlayerInTeam/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /PlayerInTeam/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,NumberOfGoals")] PlayerInTeam playerinteam)
        {
            if (ModelState.IsValid)
            {
                db.PlayerInTeams.Add(playerinteam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(playerinteam);
        }

        // GET: /PlayerInTeam/Edit/5
        public ActionResult Edit(int? id, int gameId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerInTeam playerinteam = db.PlayerInTeams.Find(id);
            if (playerinteam == null)
            {
                return HttpNotFound();
            }
            return View(playerinteam);
        }

        // POST: /PlayerInTeam/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,NumberOfGoals")] PlayerInTeam playerinteam, int gameId)
        {
            if (ModelState.IsValid)
            {
                db.Entry(playerinteam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Games", new { id = gameId });
            }
            return View(playerinteam);
        }

        // GET: /PlayerInTeam/Delete/5
        public ActionResult Delete(int? id, int gameId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerInTeam playerinteam = db.PlayerInTeams.Find(id);
            if (playerinteam == null)
            {
                return HttpNotFound();
            }
            return View(playerinteam);
        }

        // POST: /PlayerInTeam/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int gameId)
        {
            PlayerInTeam playerinteam = db.PlayerInTeams.Find(id);
            db.PlayerInTeams.Remove(playerinteam);
            db.SaveChanges();
            return RedirectToAction("Details","Games",new {id = gameId });
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
