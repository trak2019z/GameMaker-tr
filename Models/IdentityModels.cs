using Microsoft.AspNet.Identity.EntityFramework;

namespace PlayerSelector.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<PlayerSelector.Models.Player> Players { get; set; }

        public System.Data.Entity.DbSet<PlayerSelector.Models.Game> Games { get; set; }

        public System.Data.Entity.DbSet<PlayerSelector.Models.Season> Seasons { get; set; }

        public System.Data.Entity.DbSet<PlayerSelector.Models.PlayerInSeason> PlayerInSeasons { get; set; }

        public System.Data.Entity.DbSet<PlayerSelector.Models.PlayerInTeam> PlayerInTeams { get; set; }

        public System.Data.Entity.DbSet<PlayerSelector.Models.Team> Teams { get; set; }
    }
}