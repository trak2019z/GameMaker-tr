using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayerSelector.Models
{
    public class Season : IEntity
    {
        public int numberOfGames { get; set; }
        public int mostMatchesPlayer { get; set; }
        public int mostGoalsPlayer { get; set; }
        public DateTime startDay { get; set; }
        public DateTime endDay { get; set; }
        public virtual List<Game> games { get; set; }

    }
}