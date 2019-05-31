namespace PlayerSelector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thirdMigration1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PlayerInTeams", "NumberOfGoals", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PlayerInTeams", "NumberOfGoals", c => c.Int(nullable: false));
        }
    }
}
