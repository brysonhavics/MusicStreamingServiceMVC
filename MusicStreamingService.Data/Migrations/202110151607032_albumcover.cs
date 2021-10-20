namespace MusicStreamingService.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class albumcover : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Album", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Album", "Image");
        }
    }
}
