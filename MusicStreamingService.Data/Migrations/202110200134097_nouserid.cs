namespace MusicStreamingService.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nouserid : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Playlist", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Playlist", "UserId", c => c.Guid(nullable: false));
        }
    }
}
