namespace PlayerSelector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thirdMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Teams", "Goals", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teams", "Goals", c => c.Int(nullable: false));
        }
    }
}
