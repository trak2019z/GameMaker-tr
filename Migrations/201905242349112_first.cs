namespace PlayerSelector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Goals = c.Int(nullable: false),
                        Game_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.Game_Id)
                .Index(t => t.Game_Id);
            
            CreateTable(
                "dbo.PlayerInTeams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumberOfGoals = c.Int(nullable: false),
                        player_Id = c.Int(),
                        Team_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Players", t => t.player_Id)
                .ForeignKey("dbo.Teams", t => t.Team_Id)
                .Index(t => t.player_Id)
                .Index(t => t.Team_Id);
            
            CreateTable(
                "dbo.PlayerInSeasons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        numberOfGoals = c.Int(nullable: false),
                        numberOfGames = c.Int(nullable: false),
                        player_Id = c.Int(),
                        season_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Players", t => t.player_Id)
                .ForeignKey("dbo.Seasons", t => t.season_Id)
                .Index(t => t.player_Id)
                .Index(t => t.season_Id);
            
            AlterColumn("dbo.AspNetUsers", "UserName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlayerInSeasons", "season_Id", "dbo.Seasons");
            DropForeignKey("dbo.PlayerInSeasons", "player_Id", "dbo.Players");
            DropForeignKey("dbo.Teams", "Game_Id", "dbo.Games");
            DropForeignKey("dbo.PlayerInTeams", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.PlayerInTeams", "player_Id", "dbo.Players");
            DropIndex("dbo.PlayerInSeasons", new[] { "season_Id" });
            DropIndex("dbo.PlayerInSeasons", new[] { "player_Id" });
            DropIndex("dbo.PlayerInTeams", new[] { "Team_Id" });
            DropIndex("dbo.PlayerInTeams", new[] { "player_Id" });
            DropIndex("dbo.Teams", new[] { "Game_Id" });
            AlterColumn("dbo.AspNetUsers", "UserName", c => c.String());
            DropTable("dbo.PlayerInSeasons");
            DropTable("dbo.PlayerInTeams");
            DropTable("dbo.Teams");
        }
    }
}
