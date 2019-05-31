using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayerSelector.Models
{
    public class Player : IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? numberOfGoals { get; set; }
        public int? numberOfGames { get; set; }
        public int? numberOfPoints { get; set; }
        public double? goalRatio { get; set; }
        public double? gameRatio { get; set; }
        public double? pointRatio { get; set; }
    }
}