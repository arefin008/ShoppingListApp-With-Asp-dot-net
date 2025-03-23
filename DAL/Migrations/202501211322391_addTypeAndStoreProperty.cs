namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTypeAndStoreProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShoppingItems", "Type", c => c.String());
            AddColumn("dbo.ShoppingItems", "Store", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShoppingItems", "Store");
            DropColumn("dbo.ShoppingItems", "Type");
        }
    }
}
