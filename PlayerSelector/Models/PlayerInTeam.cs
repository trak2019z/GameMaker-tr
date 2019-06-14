using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayerSelector.Models
{
    public class PlayerInTeam : IEntity
    {
        private ApplicationDbContext db = new ApplicationDbContext();       
        public virtual Player player { get; set; }
        public int? NumberOfGoals { get; set; }

    }
}