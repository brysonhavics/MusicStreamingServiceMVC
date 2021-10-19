namespace MusicStreamingService.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class playlist : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Playlist",
                c => new
                    {
                        PlaylistId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Likes = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Length = c.Time(nullable: false, precision: 7),
                        Private = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PlaylistId);
            
            AddColumn("dbo.Song", "Playlist_PlaylistId", c => c.Int());
            CreateIndex("dbo.Song", "Playlist_PlaylistId");
            AddForeignKey("dbo.Song", "Playlist_PlaylistId", "dbo.Playlist", "PlaylistId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Song", "Playlist_PlaylistId", "dbo.Playlist");
            DropIndex("dbo.Song", new[] { "Playlist_PlaylistId" });
            DropColumn("dbo.Song", "Playlist_PlaylistId");
            DropTable("dbo.Playlist");
        }
    }
}
