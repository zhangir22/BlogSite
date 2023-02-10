namespace SwaggerBlogSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SwaggerdbV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.Blog",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        body = c.String(),
                        userId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "public.User",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        lastName = c.String(),
                        email = c.String(),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("public.User");
            DropTable("public.Blog");
        }
    }
}
