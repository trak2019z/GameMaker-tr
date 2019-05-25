using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayerSelector.Models
{
    public class PlayerInSeason :IEntity
    {
        public Player player { get; set; }
        public int numberOfGoals { get; set; }
        public int numberOfGames { get; set; }
        public Season season { get; set; }
    }
}