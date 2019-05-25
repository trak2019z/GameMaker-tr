using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlayerSelector.Models
{
    public class Game : IEntity
    {
        public virtual List<Team> Teams { get; set; }
        public int NumberOfPlayers { get; set; }
        public DateTime Date { get; set; }
        public bool CanSignUp { get; set; }
    }
}