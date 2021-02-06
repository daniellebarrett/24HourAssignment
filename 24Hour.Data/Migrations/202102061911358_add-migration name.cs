namespace _24Hour.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigrationname : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comment", "PostId", "dbo.Post");
            DropPrimaryKey("dbo.Comment");
            DropPrimaryKey("dbo.Post");
            DropColumn("dbo.Comment", "Id");
            DropColumn("dbo.Post", "Id");
            AddColumn("dbo.Comment", "CommentId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Post", "PostId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Comment", "CommentId");
            AddPrimaryKey("dbo.Post", "PostId");
            AddForeignKey("dbo.Comment", "PostId", "dbo.Post", "PostId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Post", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Comment", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Comment", "PostId", "dbo.Post");
            DropPrimaryKey("dbo.Post");
            DropPrimaryKey("dbo.Comment");
            DropColumn("dbo.Post", "PostId");
            DropColumn("dbo.Comment", "CommentId");
            AddPrimaryKey("dbo.Post", "Id");
            AddPrimaryKey("dbo.Comment", "Id");
            AddForeignKey("dbo.Comment", "PostId", "dbo.Post", "PostId");
        }
    }
}
