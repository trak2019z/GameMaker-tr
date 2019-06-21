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
    public class GamesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Games/
        public ActionResult Index()
        {
            return View(db.Games.ToList());
        }

        // GET: /Games/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }

            foreach (var team in game.Teams.ToList())
                setNumberOfGoals(team);

            

            var players = db.Players.ToList();

            foreach (var team in game.Teams.ToList())
            {
                foreach (var playerInTeam in team.Players.ToList())
                {
                    players.Remove(playerInTeam.player);
                }
            }

            List<string> playersToDropdown = new List<string>();

            foreach(var player in players)
            {
                string temp = String.Format("{0} - {1} {2}", player.Id, player.FirstName, player.LastName);
                playersToDropdown.Add(temp);
            }

            ViewBag.Players = playersToDropdown;

            return View(game);
        }

        // GET: /Games/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,NumberOfPlayers,Date,CanSignUp")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Games.Add(game);
                Team team_1 = new Team();
                team_1.Name = "Pierwsza drużyna";
                Team team_2 = new Team();
                team_2.Name = "Druga drużyna";
                team_1.Goals = 0;
                team_2.Goals = 0;
                game.Teams.Add(team_1);
                game.Teams.Add(team_2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(game);
        }

        // GET: /Games/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: /Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,NumberOfPlayers,Date,CanSignUp")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(game);
        }

        // GET: /Games/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: /Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game game = db.Games.Find(id);

            foreach(var team in game.Teams.ToList())
            {
                game.Teams.Remove(team);
            }
            db.Games.Remove(game);
            
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

        [HttpPost]
        public ActionResult addPlayer()
        {
            var selectedValue = Request.Form["Players"].ToString();
            var teamIdName = Request.Form["IdTeam"].ToString();
            int playerId = getPlayerId(selectedValue);
            int teamId = getTeamId(teamIdName);
            addPlayerToMatch(playerId, teamId);
            return Redirect(Request.UrlReferrer.ToString());
        }


        private void addPlayerToMatch(int playerId, int teamId)
        {
            Team team = db.Teams.Find(teamId);
            Player player = db.Players.Find(playerId);
            PlayerInTeam playerInTeam = new PlayerInTeam();
            playerInTeam.player = player;
            team.Players.Add(playerInTeam);
            db.SaveChanges();
        }

        private int getTeamId(string urlReferrer)
        {
            string[] parts = urlReferrer.Split(' ');
            return Int32.Parse(parts[parts.Length - 1]);
        }
        private int getPlayerId(string selectedValue)
        {
            string[] parts = selectedValue.Split(' ');
            return Int32.Parse(parts[0]);
        }

        private void setNumberOfGoals(Team team)
        {
            List<int?> goalsOfPlayers = new List<int?>();

            foreach(var player in team.Players.ToList())
            {
                goalsOfPlayers.Add(player.NumberOfGoals);
            }

            team.Goals = goalsOfPlayers.Sum();
            db.Teams.Attach(team);
            db.Entry(team).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
