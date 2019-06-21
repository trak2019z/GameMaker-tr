using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlayerSelector.Models
{
    public class Game : IEntity
    {
        public Game()
        {
            this.Teams = new List<Team>();
        }
        public virtual ICollection<Team> Teams { get; set; }
        public int NumberOfPlayers { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public bool CanSignUp { get; set; }
    }
}