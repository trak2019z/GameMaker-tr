//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PlayerSelector
{
    using System;
    using System.Collections.Generic;
    
    public partial class Teams
    {
        public Teams()
        {
            this.PlayerInTeams = new HashSet<PlayerInTeams>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int Goals { get; set; }
        public Nullable<int> Game_Id { get; set; }
    
        public virtual Games Games { get; set; }
        public virtual ICollection<PlayerInTeams> PlayerInTeams { get; set; }
    }
}
