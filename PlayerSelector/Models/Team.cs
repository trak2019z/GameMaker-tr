using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlayerSelector.Models
{
    public class Team : IEntity
    {
        public Team()
        {
            Players = new List<PlayerInTeam>();
        }
        public string Name { get; set; }
        public virtual ICollection<PlayerInTeam> Players { get; set; }
        public int? Goals { get; set; }
    }
}