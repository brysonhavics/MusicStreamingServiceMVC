namespace MusicStreamingService.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Song", "AlbumId", "dbo.Album");
            DropIndex("dbo.Song", new[] { "AlbumId" });
            AlterColumn("dbo.Song", "AlbumId", c => c.Int());
            CreateIndex("dbo.Song", "AlbumId");
            AddForeignKey("dbo.Song", "AlbumId", "dbo.Album", "AlbumId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Song", "AlbumId", "dbo.Album");
            DropIndex("dbo.Song", new[] { "AlbumId" });
            AlterColumn("dbo.Song", "AlbumId", c => c.Int(nullable: false));
            CreateIndex("dbo.Song", "AlbumId");
            AddForeignKey("dbo.Song", "AlbumId", "dbo.Album", "AlbumId", cascadeDelete: true);
        }
    }
}
