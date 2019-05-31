namespace PlayerSelector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Players", "numberOfGoals", c => c.Int());
            AlterColumn("dbo.Players", "numberOfGames", c => c.Int());
            AlterColumn("dbo.Players", "numberOfPoints", c => c.Int());
            AlterColumn("dbo.Players", "goalRatio", c => c.Double());
            AlterColumn("dbo.Players", "gameRatio", c => c.Double());
            AlterColumn("dbo.Players", "pointRatio", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Players", "pointRatio", c => c.Double(nullable: false));
            AlterColumn("dbo.Players", "gameRatio", c => c.Double(nullable: false));
            AlterColumn("dbo.Players", "goalRatio", c => c.Double(nullable: false));
            AlterColumn("dbo.Players", "numberOfPoints", c => c.Int(nullable: false));
            AlterColumn("dbo.Players", "numberOfGames", c => c.Int(nullable: false));
            AlterColumn("dbo.Players", "numberOfGoals", c => c.Int(nullable: false));
        }
    }
}
